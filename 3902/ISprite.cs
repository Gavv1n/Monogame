using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902
{
    public interface ISprite
    {
        // I went in a bit of different direction and included postion so I could easily compare
        // sprite and player position at any moment
        Vector2 Position { get; set; }

        void Update(GameTime gameTime, int directionRow, bool isMoving);

        void Draw(SpriteBatch spriteBatch);
    }
}
