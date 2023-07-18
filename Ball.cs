using System.Collections.Generic;
using breakout01.Helpers;
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
        private float _initialBallSpeed = 5.0f;
        private float _speed;
        private float _speedIncrease = 0.2f;
        public bool InMotion { get; set; } = false;

        public Ball(ContentManager contentManager)
        {
            _texture = contentManager.Load<Texture2D>("Sprites/Ball");
            _position = new Vector2(ScreenManager.ScreenWidth / 2, ScreenManager.ScreenHeight - 200);
            _velocity = new Vector2(1, -1);
            _speed = _initialBallSpeed;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }
        public void Update(Paddle paddle, List<Block> blocks, ScoreBoard scoreBoard, AudioManager audioManager)
        {

            Vector2 previousPosition = _position;

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
            if (_position.X >= ScreenManager.ScreenWidth - 12 - _texture.Width)
            {
                _velocity.X *= -1f;
                audioManager.AudioHitWall();
            }
            if (_position.X <= 12)
            {
                _velocity.X *= -1f;
                audioManager.AudioHitWall();
            }
            if (_position.Y <= 26)
            {
                _velocity.Y *= -1f;
                audioManager.AudioHitWall();
            }

            // Ball leaves field
            if (_position.Y > ScreenManager.ScreenHeight)
            {
                InMotion = false;
                scoreBoard.Lives--;
                _speed = _initialBallSpeed;
            }

            // Collision with paddle
            if (GetBounds().Intersects(paddle.GetBounds()))
            {
                _velocity.Y *= -1;
                _speed += _speedIncrease;
                audioManager.AudioHitPaddle();
            }


            for (int i = 0; i < blocks.Count; i++)
            {
                if (GetBounds().Intersects(blocks[i].GetBounds()))
                {
                    if (_position.Y <= blocks[i].Position.Y + blocks[i].Texture.Height && previousPosition.Y > blocks[i].Position.Y + blocks[i].Texture.Height)
                    {
                        // Block was hit from bottom
                        _velocity.Y *= -1;
                    }
                    else if(_position.Y + _texture.Height >= blocks[i].Position.Y && previousPosition.Y + _texture.Height < blocks[i].Position.Y)
                    {
                        // Block was hit from top
                        _velocity.Y *= -1;
                    }
                    else if (_position.X <= blocks[i].Position.X + blocks[i].Texture.Width && previousPosition.Y > blocks[i].Position.X + blocks[i].Texture.Width)
                    {
                        // Block was hit from right
                        _velocity.X *= -1;
                    }
                    else if (_position.X + _texture.Width >= blocks[i].Position.X && previousPosition.X + _texture.Width < blocks[i].Position.X)
                    {
                        // Block was hit from left
                        _velocity.X *= -1;
                    }

                    blocks.Remove(blocks[i]);
                    audioManager.AudioHitBlock();
                    scoreBoard.Score += blocks[i].Points;
                }
            }


            
        }

        public void Draw()
        {
            Breakout.sSpriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
