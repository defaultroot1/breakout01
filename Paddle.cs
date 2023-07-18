using breakout01.Content.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace breakout01
{
    internal class Paddle
    {
        public Texture2D Texture { get; private set; }
        public Vector2 Position { get; private set; }
        private KeyboardState _keyboardState;
        private float _speed = 3f;

        public Paddle(ContentManager contentManager, ScreenHelper screenHelper)
        {
            Texture = contentManager.Load<Texture2D>("Sprites/Paddle");
            Position = new Vector2(screenHelper.ScreenWidth / 2, screenHelper.ScreenHeight * 0.94f);
        }
        public Rectangle GetBounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public void Update(ScreenHelper screenHelper, Ball ball)
        {
            _keyboardState = Keyboard.GetState();

            if (_keyboardState.IsKeyDown(Keys.A))
            {
                Position = new Vector2(Position.X - _speed, Position.Y);
            }
            if (_keyboardState.IsKeyDown(Keys.D))
            {
                Position = new Vector2(Position.X + _speed, Position.Y);
            }

            if (_keyboardState.IsKeyDown(Keys.Space) && !ball.InMotion)
            {
                ball.InMotion = true;
            }

            Position = new Vector2(MathHelper.Clamp(Position.X, 12, screenHelper.ScreenWidth - 12 - Texture.Width), Position.Y);

            //Position = MathHelper.Clamp(Position.X, 12, screenHelper.ScreenWidth - 12 - Texture.Width);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
