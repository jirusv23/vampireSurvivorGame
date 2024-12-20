using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace notVampireSurvivor
{
    internal class Rect
    {
        Vector2 positionInWorld;
        Vector2 viewportPosition;
        Vector2 playerPosition;

        Texture2D texture;

        public Rect(Vector2 position, Player hrac, GraphicsDevice graphics, int sirka, int vyska, Color color)
        {
            texture = new Texture2D(graphics, sirka, vyska);

            Color[] data = new Color[sirka * vyska];
            for (int i = 0; i < data.Length; ++i) data[i] = color;
            texture.SetData(data);

            this.positionInWorld = position;
            this.positionInWorld.X -= sirka / 2; 
            this.positionInWorld.Y -= vyska / 2;

            playerPosition = hrac.playerMovement;
            viewportPosition = new Vector2(positionInWorld.X - playerPosition.X, positionInWorld.Y - playerPosition.Y);
        }

        public void Draw(SpriteBatch _spriteBatch, Player hrac)
        {
            playerPosition = hrac.playerMovement;
            viewportPosition = new Vector2(positionInWorld.X - playerPosition.X, positionInWorld.Y - playerPosition.Y);

            _spriteBatch.Draw(texture, viewportPosition, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
        }
    }
}
