using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace breakout01
{
    internal class Block
    {
        public Texture2D Texture { get; set; }
        public int Points { get; set; }
        public Vector2 Position { get; set; }

        public Block(ContentManager contentManager, Vector2 position, string colour, int points)
        {
            switch (colour)
            {
                case "yellow":
                    Texture = contentManager.Load<Texture2D>("Sprites/YellowBrick");
                    break;
                case "green":
                    Texture = contentManager.Load<Texture2D>("Sprites/GreenBrick");
                    break;
                case "orange":
                    Texture = contentManager.Load<Texture2D>("Sprites/OrangeBrick");
                    break;
                case "red":
                    Texture = contentManager.Load<Texture2D>("Sprites/RedBrick");
                    break;
            }

            Position = position;
            Points = points;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public void Draw()
        {
            Breakout.sSpriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
