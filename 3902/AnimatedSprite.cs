using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902
{
    public class AnimatedSprite : ISprite
    {
        // A LOT OF ASSIGNMENT.
        // We need a lot of information to animate such as the width and height of each sprite,
        // the number of columns per spritesheet, how many seconds per
        // each frame, current frame, a timer, whether the sprite is moving, and the
        // direction that it will face. Oh and also the position which i just have set to (0, 0)
        // but since its a property it will just get and set that. We also have the timer in order
        // to incorporate the idle sheet.
        private Texture2D _idle;
        private Texture2D _walk;

        private int _frameWidth;
        private int _frameHeight;
        private int _idleFrameCount;
        private int _walkFrameCount;
        private float _secondsPerFrame;

        private int _currentFrame;
        private float _timer;
        private bool _isMoving;
        private int _direction;

        public Vector2 Position { get; set; }

        public AnimatedSprite(
            Texture2D idle,
            Texture2D walk,
            // sprite sheet frames height and width
            int frameWidth = 32,
            int frameHeight = 32,
            //number of columns per each sheet
            int idleFrameCount = 4,
            int walkFrameCount = 6,
            // i honestly just changed this til it looked natural and got here.
            float secondsPerFrame = 0.10f)
        {
            // assignment
            _idle = idle;
            _walk = walk;
            _frameWidth = frameWidth;
            _frameHeight = frameHeight;
            _idleFrameCount = idleFrameCount;
            _walkFrameCount = walkFrameCount;
            _secondsPerFrame = secondsPerFrame;
        }

        public void Update(GameTime gameTime, int direction, bool isMoving)
        {
            // Switching sheets means switching frame counts (4 idle vs 6 walk),
            // so reset back to frame 0 to avoid indexing past the shorter sheet.
            if (isMoving != _isMoving)
            {
                _currentFrame = 0;
                _timer = 0f;
            }

            // assignment
            _isMoving = isMoving;
            _direction = direction;

            // if moving change the framecount to walkings frame count if not change to idle's
            // pretty self explanatory
            int frameCount;
            if (_isMoving)
            {
                frameCount = _walkFrameCount;
            }
            else
            {
                frameCount = _idleFrameCount;
            }
            //add to timer
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            // Probably the most complex thing out of the whole sprint that I had to code. LOL
            // ok so basically we need to cap the amount of frames being shown. We do this by
            // having a secondsPerFrame and comparing it to a timer. Once the time reaches or overtakes
            // the required seconds per frame, we then reset the timer and this is the cool part. 
            // We add to the current frame and check it with our frame count. So for example if 
            // the current frame was 3 and our frame count is 4 for idle (3+1) % 4 = 0 and the 
            // frame resets back to the first! I. E 0 -> 1 -> 2 -> 3 -> 0 -> .... 
            if (_timer >= _secondsPerFrame)
            {
                _timer = 0f;
                _currentFrame = (_currentFrame + 1) % frameCount;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Again pretty self explanatory but if movement then change the texture
            // move = walking texture, idle if not
            Texture2D texture;
            if (_isMoving)
            {
                texture = _walk;
            }
            else
            {
                texture = _idle;
            }
            // here to pick out the specific frame to draw by cropping basically
            Rectangle sourceRectangle = new Rectangle(
                _currentFrame * _frameWidth, _direction * _frameHeight,
                _frameWidth, _frameHeight);
                // using the longer draw parameters in order to access the scale feature.Sx cvb
            spriteBatch.Draw(texture, Position, sourceRectangle, Color.White, 0f, Vector2.Zero, 1.75f, SpriteEffects.None, 0f);
        }
    }
}
