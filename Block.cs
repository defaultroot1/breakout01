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
        private Vector2 _position;

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

            _position = position;
            Points = points;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, Texture.Width, Texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _position, Color.White);
        }
    }
}
