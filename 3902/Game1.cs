using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3902
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private IPlayer _player;

        private SpriteFont font;
        private SpriteFont URL;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            // load container for sprites and the spritesheets. also initialize the animated
            // sprite with the textures as parameters. the sprite font as well for name,
            // credits etc.
            font = Content.Load<SpriteFont>("Name");
            URL = Content.Load<SpriteFont>("URL");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D idle = Content.Load<Texture2D>("images/Fox_Idle_with_shadow");
            Texture2D walk = Content.Load<Texture2D>("images/Fox_walk_with_shadow");

            ISprite sprite = new AnimatedSprite(idle, walk);
            // load keyboard controller with the sprite so it can get sprites pos and update it
            // after usage
            IController controller = new KeyboardController(sprite);
            // load player
            _player = new Player(controller, sprite);
        }

        // pretty self explanatory. if you wanna quit press escape. player will update, gametime will update.
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            _player.Update(gameTime);

            base.Update(gameTime);
        }

        // start the sprite batch, draw the player, and end the sprite batch
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            // each of these spritebatch drawing is the text thats shown in the bottom right.
            // I needed a separate spritefont to change the size to fit the url.
            _spriteBatch.DrawString(font, "Credits", new Vector2(10,360), Color.Black);
            _spriteBatch.DrawString(font, "Program Made By: Gavin Brooks", new Vector2(10,400), Color.Black);
            _spriteBatch.DrawString(URL, "Sprites from: https://craftpix.net/freebies/free-top-down-hunt-animals-pixel-sprite-pack/",
             new Vector2(10,450), Color.Black);
            _player.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
