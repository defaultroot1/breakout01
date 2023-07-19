using breakout01.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace breakout01
{
    internal class ScoreBoard
    {
        private SpriteFont _font;
        public int Score { get; set; }
        public int Lives { get; set; } = 1;
        private string _gameOverMessage = "GAME OVER";
        private Vector2 _textSize;




        public ScoreBoard(ContentManager contentManager)
        {
            _font = contentManager.Load<SpriteFont>("Fonts/scoreFont");
            _textSize = _font.MeasureString(_gameOverMessage);
        }

        public void Draw()
        {
            Breakout.sSpriteBatch.DrawString(_font, Lives.ToString(), new Vector2(15, 25), Color.White);


            Breakout.sSpriteBatch.DrawString(_font, Score.ToString("D3"), new Vector2(70, 80), Color.White);
        }

        public void GameOver()
        {
            float centerX = (ScreenManager.ScreenWidth - _textSize.X) / 2;

            Breakout.sSpriteBatch.DrawString(
                _font, 
                _gameOverMessage,
                new Vector2(centerX, ScreenManager.ScreenHeight / 2), 
                Color.White);

        }

    }
}
