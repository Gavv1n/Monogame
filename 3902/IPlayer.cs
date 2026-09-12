using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902
{
    public interface IPlayer
    {
        // I went in a bit of different direction and included postion so I could easily compare
        // sprite and player position at any moment
        Vector2 Position { get; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
