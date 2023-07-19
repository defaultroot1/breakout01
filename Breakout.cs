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
        public static SpriteBatch sSpriteBatch;
        public static ContentManager sContentMananger;

        public enum GameState
        {
            Playing,
            GameOver
        }
        public static GameState gameState;

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
            
            gameState = GameState.Playing;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _scoreBoard = new ScoreBoard(Content);
            sSpriteBatch = new SpriteBatch(GraphicsDevice);
            _audioManager = new AudioManager(Content);
            _gameField = new GameField(Content);
            _paddle = new Paddle(Content);
            _ball = new Ball(Content);
            _blockManager = new BlockManager(Content);


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (gameState)
            {
                case GameState.Playing:
                    _paddle.Update(_ball);
                    _ball.Update(_paddle, _blockManager.Blocks, _scoreBoard, _audioManager);
                    break;
                case GameState.GameOver:
                    // No updates? Maybe check for key to restart
                    break;
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            sSpriteBatch.Begin();

            switch (gameState)
            {
                case GameState.Playing:
                    _gameField.Draw();
                    _scoreBoard.Draw();
                    _paddle.Draw();
                    _ball.Draw();
                    _blockManager.Draw();
                    break;
                case GameState.GameOver:
                    _gameField.Draw();
                    _scoreBoard.Draw();
                    _paddle.Draw();
                    _blockManager.Draw();
                    _scoreBoard.GameOver();
                    break;
            }



            
            sSpriteBatch.End();

            base.Draw(gameTime);
        }

    }
}