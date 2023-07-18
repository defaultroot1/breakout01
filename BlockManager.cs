using System.Collections.Generic;
using breakout01.Content.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace breakout01
{
    internal class BlockManager
    {
        public List<Block> Blocks { get; set; }

        public BlockManager(ContentManager contentManager)
        {
            Blocks = new List<Block>();

            
            int verticalGap = 15;
            string colour = null;
            int points = 0;

            for (int i = 0; i < 8; i++)
            {
                int blockX = 13;
                switch (i)
                {
                    case 0:
                    case 1:
                        colour = "yellow";
                        points = 1;
                        break;
                    case 2:
                    case 3:
                        colour = "green";
                        points = 3;
                        break;
                    case 4:
                    case 5:
                        colour = "orange";
                        points = 5;
                        break;
                    case 6:
                    case 7:
                        colour = "red";
                        points = 7;
                        break;
                }

                for (int j = 0; j < 14; j++)
                {
                    Blocks.Add(new Block(
                        contentManager,
                        new Vector2(blockX, 247 - (verticalGap * i)),
                        colour,
                        points));

                    blockX += 41;
                }
            }



        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block block in Blocks)
            {
                block.Draw(spriteBatch);
            }
        }
    }


}
