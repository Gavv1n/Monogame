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
        private IPlayer _player2;

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
            Texture2D idleF = Content.Load<Texture2D>("images/Fox_Idle_with_shadow");
            Texture2D walkF = Content.Load<Texture2D>("images/Fox_walk_with_shadow");
            Texture2D idleB = Content.Load<Texture2D>("images/Boar_Idle_with_shadow");
            Texture2D walkB = Content.Load<Texture2D>("images/Boar_walk_with_shadow");


            ISprite sprite = new AnimatedSprite(idleF, walkF);
            ISprite sprite2 = new AnimatedSprite(idleB, walkB);
            // load keyboard controller with the sprite so it can get sprites pos and update it
            // after usage
            IController mController = new MouseController(sprite);
            IController kbController = new KeyboardController(sprite2);
            // load player
            _player = new Player(mController, sprite);
            _player2 = new Player(kbController, sprite2);

        }

        // pretty self explanatory. if you wanna quit press escape. player will update, gametime will update.
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            _player.Update(gameTime);
            _player2.Update(gameTime);

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
            _player2.Draw(_spriteBatch);
            _player.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
