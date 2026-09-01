using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonSlime;

public class Game1 : Game
{
    // the window that opens up when the game is run, this is where all the graphics will be drawn
    private GraphicsDeviceManager _graphics;
    // container that collects batches of sprites to be drawn to the screen, this is used to draw all the graphics in the game
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        //look more into this
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // cannot use content loading object to collect data from image files, sounds, etc. until the game is initialized

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        //stores a snapshot of all the keys pressed at on the keyboard at a given moment
        KeyboardState ks = Keyboard.GetState();
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || ks.IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
