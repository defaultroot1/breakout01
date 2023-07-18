﻿using breakout01.Content.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace breakout01
{
    internal class Ball
    {
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _velocity;
        private float _speed = 3.0f;
        public bool InMotion { get; set; } = false;

        public Ball(ContentManager contentManager, ScreenHelper screenHelper)
        {
            _texture = contentManager.Load<Texture2D>("Sprites/Ball");
            _position = new Vector2(screenHelper.ScreenWidth / 2, screenHelper.ScreenHeight - 200);
            _velocity = new Vector2(1, -1);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }
        public void Update(ScreenHelper screenHelper, Paddle paddle)
        {
            if (InMotion)
            {
                _position += _velocity * _speed;
            }
            else
            {
                // Ball sticks to paddle ready to launch. Some math to center it
                _position = new Vector2(paddle.Position.X + paddle.Texture.Width / 2 - _texture.Width / 2,
                    paddle.Position.Y - _texture.Height);
            }


            // Some hardcoded values to detect collision with the game borders
            if (_position.X >= screenHelper.ScreenWidth - 12 - _texture.Width)
            {
                _velocity.X *= -1f;
            }
            if (_position.X <= 12)
            {
                _velocity.X *= -1f;
            }
            if (_position.Y <= 26)
            {
                _velocity.Y *= -1f;
            }

            if (GetBounds().Intersects(paddle.GetBounds()))
            {
                _velocity.Y *= -1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
