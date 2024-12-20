using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace notVampireSurvivor
{
    internal class Player
    {
        readonly Texture2D playerTexture;

        internal Rectangle playerHitbox;
        internal Vector2 playerMovement;

        int rychlost;

        const float division = 30f;
        float dividedLenght;
        float ratio;
        float sirka;
        float vyska;

        public Player(Texture2D texture, int sirkaOkna, int vyskaOkna, Vector2 worldOrigin)
        {
            playerTexture = texture;
            rychlost = 10;

            dividedLenght = sirkaOkna / division; //lenght of one part of divided screen
            ratio = dividedLenght / playerTexture.Width;
            sirka = ratio * playerTexture.Width;
            vyska = ratio * playerTexture.Height;

            // only used for detecting collision - cons
            playerHitbox = new Rectangle((sirkaOkna / 2 - (int)(sirka) / 2),
                                         (vyskaOkna / 2 - (int)(sirka) / 2),
                                         (int)(sirka),
                                         (int)(vyska));

            //tracks how the player moved
            playerMovement = new Vector2(worldOrigin.X - sirkaOkna / 2,
                                         worldOrigin.Y - vyskaOkna / 2);
        }

        public void vykresliSe(SpriteBatch _spriteBatch, int sirkaOkna, int vyskaOkna)
        {
            // Draws player always in the middle of the screen
            _spriteBatch.Draw(playerTexture,
                              new Vector2(sirkaOkna / 2 - (int)(sirka) / 2,
                                         vyskaOkna / 2 - (int)(sirka) / 2),
                              null,
                              Color.White,
                              0f,
                              Vector2.Zero,
                              ratio,
                              SpriteEffects.None,
                              0.5f); //layer depth (0 is closest)
        }

        public void Pohyb(Keys horni, Keys dolni, Keys vlevo, Keys pravo)
        {
            if (Keyboard.GetState().IsKeyDown(horni))
            {
                playerMovement.Y -= rychlost;
                playerHitbox.Y -= rychlost;
            }
            else if (Keyboard.GetState().IsKeyDown(dolni))
            {
                playerMovement.Y += rychlost;
                playerHitbox.Y += rychlost;
            }

            if (Keyboard.GetState().IsKeyDown(pravo))
            {
                playerMovement.X += rychlost;
                playerHitbox.X += rychlost;
            }
            else if (Keyboard.GetState().IsKeyDown(vlevo))
            {
                playerMovement.X -= rychlost;
                playerHitbox.X -= rychlost;
            }
        }
    }
}
