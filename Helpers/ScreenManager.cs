using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace breakout01.Helpers
{
    public static class ScreenManager
    {
        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }

        public static void Init(GraphicsDeviceManager graphics)
        {
            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;
        }
    }

}
