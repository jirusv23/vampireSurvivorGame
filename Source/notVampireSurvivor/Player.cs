using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace notVampireSurvivor
{
    internal class Player
    {
        Texture2D playerTexture;
        Rectangle playerRectangel;

        int rychlost;

        public Player(Texture2D texture, int sirkaOkna, int vyskaOkna)
        {
            playerTexture = texture;

            playerRectangel = new Rectangle(sirkaOkna/2 - playerTexture.Width/2, vyskaOkna/2 - playerTexture.Height/2, playerTexture.Width, playerTexture.Height);
            Debug.WriteLine(sirkaOkna / 2 - playerTexture.Width / 2);
            Debug.WriteLine(vyskaOkna / 2 - playerTexture.Height / 2);
            Debug.WriteLine(playerTexture.Width);
            Debug.WriteLine(playerTexture.Height);
        }

        public void vykresliSe(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(playerTexture, playerRectangel, Color.White);
        }
    }
}
