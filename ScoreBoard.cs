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
        public int Lives { get; set; } = 5;

        public ScoreBoard(ContentManager contentManager)
        {
            _font = contentManager.Load<SpriteFont>("Fonts/scoreFont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, Lives.ToString(), new Vector2(15, 25), Color.White);
            spriteBatch.DrawString(_font, Score.ToString("D3"), new Vector2(70, 80), Color.White);
        }

    }
}
