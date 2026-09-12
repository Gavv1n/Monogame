using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _3902
{

    public class KeyboardController : IController
    {
        // Row indices matching the sprite sheet layout: 0 down, 1 up, 2 Left, 3 right.
        private const int RowDown = 0;
        private const int RowUp = 1;
        private const int RowLeft = 2;
        private const int RowRight = 3;

        private ISprite _sprite;
        private float _speed;
        //set this to down at the beginning just because sprites usually face user off start.
        private int direction = RowDown;

        public KeyboardController(ISprite sprite, float speed = 120f)
        {
            _sprite = sprite;
            _speed = speed;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Vector2 move = Vector2.Zero;

            // literally if a key is pressed move 1 space in a direction I.E A = -1 for right
            if (keyboardState.IsKeyDown(Keys.A))
            {
                move.X -= 1;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                move.X += 1;
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                move.Y -= 1;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                move.Y += 1;
            }

            // check if any input
            bool isMoving = false; 
            if (move.X != 0 || move.Y != 0)
            {
                isMoving = true;
            }

            if (isMoving)
            {
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
            }

            // update the sprite
            _sprite.Update(gameTime, direction, isMoving);
        }
    }
}
