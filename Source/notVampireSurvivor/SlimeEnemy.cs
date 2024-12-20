﻿using Microsoft.Xna.Framework;
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

        Vector2 positionInWorld;
        Vector2 viewportPosition;
        public SlimeEnemy(Texture2D sourceTextura, Player hrac)
        {
            texture = sourceTextura;

            int targetedWidth = 72;
            int widthOfTexture = texture.Width;
            float ratio = (float)targetedWidth / (float)widthOfTexture;
            scalingFactor = ratio;

            positionInWorld = new Vector2(500, 250);

            Vector2 playerPosition = hrac.playerMovement;
            viewportPosition = new Vector2(positionInWorld.X - playerPosition.X, positionInWorld.Y - playerPosition.Y);
        }

        public void Draw(SpriteBatch _spriteBatch, Player hrac)
        {
            Vector2 playerPosition = hrac.playerMovement;
            viewportPosition = new Vector2(positionInWorld.X - playerPosition.X, positionInWorld.Y - playerPosition.Y);

            _spriteBatch.Draw(texture, viewportPosition, null, Color.White, 0f, Vector2.Zero, scalingFactor, SpriteEffects.None, 0f);
        }
    }
}
 