using breakout01.Content.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace breakout01
{
    internal class Paddle
    {
        private Texture2D _texture;
        private Vector2 _position;
        private KeyboardState _keyboardState;
        private float _speed = 3f;

        public Paddle(ContentManager contentManager, ScreenHelper screenHelper)
        {
            _texture = contentManager.Load<Texture2D>("Sprites/Paddle");
            _position = new Vector2(screenHelper.ScreenWidth / 2, screenHelper.ScreenHeight * 0.94f);
        }
        public Rectangle GetBounds()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }

        public void Update(ScreenHelper screenHelper)
        {
            _keyboardState = Keyboard.GetState();

            if (_keyboardState.IsKeyDown(Keys.A))
            {
                _position.X -= _speed;
            }
            if (_keyboardState.IsKeyDown(Keys.D))
            {
                _position.X += _speed;
            }

            _position.X = MathHelper.Clamp(_position.X, 12, screenHelper.ScreenWidth - 12 - _texture.Width);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
