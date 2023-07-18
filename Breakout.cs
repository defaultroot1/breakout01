using breakout01.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace breakout01
{
    public class Breakout : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private ScoreBoard _scoreBoard;
        private AudioManager _audioManager;

        private GameField _gameField;
        private Paddle _paddle;
        private Ball _ball;
        private BlockManager _blockManager;


        public Breakout()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            ScreenManager.ScreenWidth = _graphics.PreferredBackBufferWidth;
            ScreenManager.ScreenHeight = _graphics.PreferredBackBufferHeight;

            _audioManager = new AudioManager(Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _scoreBoard = new ScoreBoard(Content);

            _gameField = new GameField(Content);
            _paddle = new Paddle(Content);
            _ball = new Ball(Content);
            _blockManager = new BlockManager(Content);


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _paddle.Update(_ball);
            _ball.Update(_paddle, _blockManager.Blocks, _scoreBoard, _audioManager);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _gameField.Draw(_spriteBatch);
            _scoreBoard.Draw(_spriteBatch);
            _paddle.Draw(_spriteBatch);
            _ball.Draw(_spriteBatch);
            _blockManager.Draw(_spriteBatch);

            
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}