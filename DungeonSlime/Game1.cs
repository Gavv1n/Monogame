using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace DungeonSlime;

public class Game1 : Core
{
    private Texture2D _texture;
    public Game1() : base("Dungeon Slime", 1280, 720, false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // load my sprites
        _texture = Content.Load<Texture2D>("images/Fox_walk_with_shadow");
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        //select a single sprite from the spritesheet
        Rectangle SpriteRectangle = new Rectangle(0, 0, 32, 32);
        // Start drawing sprites
        SpriteBatch.Begin();

            // Draw the logo texture.
    SpriteBatch.Draw(
        _texture,          // texture
        new Vector2(    // position
            (Window.ClientBounds.Width * 0.5f) - (SpriteRectangle.Width * 0.5f), 
            (Window.ClientBounds.Height * 0.5f) - (SpriteRectangle.Height * 0.5f)),
            SpriteRectangle,               // sourceRectangle
            Color.White * 1.0f,        // color and also opacity
            MathHelper.ToRadians(360),               // rotation
            new Vector2(0, 0),       // origin
            1.0f,               // scale
            SpriteEffects.None, // effects
            0.0f                // layerDepth
        );
        
        //end the sprite batch
        SpriteBatch.End();
        base.Draw(gameTime);
    }
}
