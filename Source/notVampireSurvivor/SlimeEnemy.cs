using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Security.Cryptography;

namespace notVampireSurvivor
{
    internal class SlimeEnemy
    {
        Texture2D texture;
        float scalingFactor;

        internal Vector2 positionInWorld;
        Vector2 viewportPosition;
        internal Rectangle slimeRectangle;
        Vector2 playerPosition;

        Vector2 rychlostVector = new Vector2(0, 0);
        int rychlost;
        public SlimeEnemy(Texture2D sourceTextura, Player hrac, Vector2 spawnPosition, int rychlost)
        {
            texture = sourceTextura;

            int targetedWidth = 72;
            int widthOfTexture = texture.Width;
            int heightOfTexture = texture.Height;
            float ratio = (float)targetedWidth / (float)widthOfTexture;
            scalingFactor = ratio;

            positionInWorld = new Vector2(spawnPosition.X - widthOfTexture*scalingFactor/2, spawnPosition.Y - heightOfTexture*scalingFactor / 2);

            playerPosition = hrac.playerMovement;
            viewportPosition = new Vector2(positionInWorld.X - playerPosition.X, positionInWorld.Y - playerPosition.Y);

            slimeRectangle = new Rectangle((int)viewportPosition.X,
                                           (int)viewportPosition.Y,
                                           (int)(widthOfTexture * scalingFactor),
                                           (int)(heightOfTexture * scalingFactor));

            this.rychlost = rychlost;
        }

        public void Update(Player hrac)
        {
            playerPosition = hrac.playerMovement;

            viewportPosition.X = positionInWorld.X - playerPosition.X;
            viewportPosition.Y = positionInWorld.Y - playerPosition.Y;
        }

        public void Draw(SpriteBatch _spriteBatch, Player hrac)
        {
            // viewportPosition = new Vector2(positionInWorld.X - playerPosition.X, positionInWorld.Y - playerPosition.Y);

            _spriteBatch.Draw(texture, viewportPosition, null, Color.White, 0f, Vector2.Zero, scalingFactor, SpriteEffects.None, 0.9f);
        }

        public void PohybTowardPlayer(Player hrac)
        {
            Vector2 target = new Vector2(hrac.playerHitbox.X, hrac.playerHitbox.Y);

            Vector2 direction = target - positionInWorld;
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
                positionInWorld += direction * rychlost;

                slimeRectangle.X = (int)direction.X * rychlost;
                slimeRectangle.Y = (int)direction.Y * rychlost;
            }

        }
    }
}
 