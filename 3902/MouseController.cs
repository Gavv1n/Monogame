using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _3902
{

    public class MouseController : IController
    {
        // Row indices matching the sprite sheet layout: 0 down, 1 up, 2 Left, 3 right.
        private const int RowDown = 0;
        private const int RowUp = 1;
        private const int RowLeft = 2;
        private const int RowRight = 3;

        private ISprite _sprite;
        private float _speed;
        private Vector2? _destination;

        private const float ArriveThreshold = 4f; // how close counts as "arrived"
        private MouseState _previousMouseState;

        //set this to down at the beginning just because sprites usually face user off start.
        private int direction = RowDown;

        public MouseController(ISprite sprite)
        {
            _sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed &&
                _previousMouseState.LeftButton == ButtonState.Released)
            {
                _destination = new Vector2(mouseState.X, mouseState.Y);
            }

            // check if any input
            bool isMoving = false; 
            if (_destination.HasValue)
            {
                Vector2 toDestination = _destination.Value - _sprite.Position;
                if (toDestination.Length() <= ArriveThreshold)
                {
                    _destination = null;
                }
                else
                {
                    Vector2 move = toDestination;
                // Mainly to prevent moving on the diagonals because my spritesheet doesn't have diagonal
                // sprites
                if (move.X != 0)
                {
                   move.Y = 0;
                }

                // Literally just to determine if the direction should be facing right, left, up, or down
                // very barebones. If the vector is being changed in either direction x or y it will 
                // go into the conditional
                    if (move.X != 0){
                        if (move.X > 0)
                        {
                            direction = RowRight;
                        }
                        else
                        {
                            direction = RowLeft;
                        }
                    } 
                    if (move.Y != 0){
                        if (move.Y > 0)
                        {
                            direction = RowDown;
                        }
                        else
                        {
                            direction = RowUp;
                        }
                    }
                    // we can figure out the position by finding the total num of seconds and multiplying it by
                // said vector * the speef * total seconds. We also have to type cast bc we dont want a weird error when
                // .totalseconds returns an int
                float timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
                _sprite.Position += move * _speed * timer;
                isMoving = true;
                }
            }

            // update the sprite
            _sprite.Update(gameTime, direction, isMoving);
        }
    }
}
