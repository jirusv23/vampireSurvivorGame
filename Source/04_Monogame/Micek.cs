using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _04_Monogame
{
    class Micek
    {
        // atributy
        Texture2D mojeTextura;

        int velikost;

        float poloha_x;
        float poloha_y;

        Vector2 rychlost;

        // konstruktor
        public Micek(GraphicsDevice grafika, int sirkaOkna, int vyskaOkna)
        {
            Random nahoda = new Random();

            velikost = nahoda.Next(20, 150);

            float rychlost_x = nahoda.Next(100) - 50;
            float rychlost_y = nahoda.Next(100) - 50;

            rychlost = new Vector2(rychlost_x, rychlost_y);
            rychlost.Normalize();
            rychlost *= (nahoda.Next(10) + 1);

            poloha_x = nahoda.Next(0, sirkaOkna - velikost);
            poloha_y = nahoda.Next(0, vyskaOkna - velikost);

            mojeTextura = new Texture2D(grafika, velikost, velikost);

            Color[] pixely = new Color[velikost * velikost];

            int r = nahoda.Next(256);
            int g = nahoda.Next(256);
            int b = nahoda.Next(256);

            for (int i = 0; i < velikost; i++)
            {
                for (int j = 0; j < velikost; j++)
                {
                    int x = j - velikost / 2;
                    int y = i - velikost / 2;

                    if (x * x + y * y < velikost / 2 * velikost / 2)
                        pixely[i * velikost + j] = new Color(r, g, b);
                    else
                        pixely[i * velikost + j] = Color.Transparent;
                }
            }

            mojeTextura.SetData(pixely);
        }

        // metody
        public void PohniSe(int sirkaOkna, int vyskaOkna)
        {
            poloha_x += rychlost.X;
            poloha_y += rychlost.Y;

            if (poloha_x + velikost > sirkaOkna || poloha_x < 0)
                rychlost.X *= -1;
            if (poloha_y + velikost > vyskaOkna || poloha_y < 0)
                rychlost.Y *= -1;
        }

        public void VykresliSe(SpriteBatch vykreslovac)
        {
            vykreslovac.Draw(mojeTextura, new Vector2(poloha_x, poloha_y), Color.White);
        }
    }
}
