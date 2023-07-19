using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using breakout01;
using Microsoft.Xna.Framework.Content;

namespace breakout01
{
    internal class GameManager
    {
        private ScoreBoard _scoreBoard;
        private enum GameState
        {
            Playing,
            Paused,
            GameOver
        }

        public GameManager(ContentManager contentManager)
        {
            _scoreBoard = new ScoreBoard(contentManager);
        }


        public void Update()
        {
            //
        }

        public void Draw()
        {
            _scoreBoard.Draw();
        }
    }
}
