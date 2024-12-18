using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace notVampireSurvivor
{
    internal class Player
    {
        readonly Texture2D playerTexture;

        Rectangle playerHitbox;
        public Vector2 playerMovement;

        int rychlost;

        const float division = 30f;
        float dividedLenght;
        float ratio;
        float sirka;
        float vyska;

        public Player(Texture2D texture, int sirkaOkna, int vyskaOkna)
        {
            playerTexture = texture;
            rychlost = 2;

            dividedLenght = sirkaOkna / division; //lenght of one part of divided screen
            ratio = dividedLenght / playerTexture.Width;
            sirka = ratio * playerTexture.Width;
            vyska = ratio * playerTexture.Height;

            // only used for detecting collision - cons
            playerHitbox = new Rectangle(sirkaOkna / 2 - (int)(sirka) / 2,
                                         vyskaOkna / 2 - (int)(sirka) / 2,
                                         (int)(sirka),
                                         (int)(vyska));


            //tracks how the player moved
            playerMovement = new Vector2(playerHitbox.X,
                                         playerHitbox.Y);


        }

        public void vykresliSe(SpriteBatch _spriteBatch, int sirkaOkna, int vyskaOkna)
        {
            // Draws player always in the middle of the screen
            _spriteBatch.Draw(playerTexture,
                              new Vector2(playerHitbox.X,
                                          playerHitbox.Y),
                              null,
                              Color.White,
                              0f,
                              Vector2.Zero,
                              ratio,
                              SpriteEffects.None,
                              0.5f); //layer depth (0 is closest)
        }

        public void Pohyb()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                playerMovement.Y += rychlost;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                playerMovement.Y -= rychlost;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                playerMovement.X += rychlost;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                playerMovement.X -= rychlost;
            }
        }
    }
}
