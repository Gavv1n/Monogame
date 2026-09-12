using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902
{
    public class Player : IPlayer
    {
        private IController _controller;
        private ISprite _sprite;

        // pull the sprites position. basically I didn't set up the players position because
        // we don't need it for sprint 0
        public Vector2 Position
        {
            get
            {
                return _sprite.Position;
            }
        }

        // assign vals
        public Player(IController controller, ISprite sprite)
        {
            _controller = controller;
            _sprite = sprite;
        }

        // update the controller
        public void Update(GameTime gameTime)
        {
            _controller.Update(gameTime);
        }

        // draw the sprite by calling sprites draw method
        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }
    }
}
