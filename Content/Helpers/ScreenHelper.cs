using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakout01.Content.Helpers
{
    internal class ScreenHelper
    {
        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        public ScreenHelper(int screenWidth, int screenHeight)
        {
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
        }
    }
}
