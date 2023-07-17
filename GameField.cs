using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace breakout01
{
    internal class GameField
    {
        private Texture2D _texture;

        public GameField(ContentManager contentManager)
        {
            _texture = contentManager.Load<Texture2D>("Sprites/Background");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, Vector2.Zero, Color.White);
            spriteBatch.End();
        }
    }
}
