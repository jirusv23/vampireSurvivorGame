using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace notVampireSurvivor
{
    internal class SlimeEnemy
    {
        Texture2D texture;
        float scalingFactor;

        Vector2 position;
        public SlimeEnemy(Texture2D sourceTextura)
        {
            texture = sourceTextura;

            int targetedWidth = 72;
            int widthOfTexture = texture.Width;
            float ratio = targetedWidth / widthOfTexture;

            scalingFactor = ratio;

            position = new Vector2(500, 250);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, scalingFactor, SpriteEffects.None, 0f);
        }
    }
}
