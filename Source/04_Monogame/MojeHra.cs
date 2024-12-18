using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace _04_Monogame
{
    public class MojeHra : Game
    {
        // atributy
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        int sirkaOkna = 1280;
        int vyskaOkna = 800;

        List<Micek> mojeMicky;
        int pocetMicku = 2000;

        // konstruktor
        public MojeHra()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        // metody
        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = sirkaOkna;
            _graphics.PreferredBackBufferHeight = vyskaOkna;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            mojeMicky = new List<Micek>();

            for(int i = 0; i < pocetMicku; i++)
                mojeMicky.Add(new Micek(GraphicsDevice, sirkaOkna, vyskaOkna));
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach(Micek m in mojeMicky)
                m.PohniSe(sirkaOkna, vyskaOkna);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Wheat);
            
            _spriteBatch.Begin();
            foreach(Micek m in mojeMicky)
                m.VykresliSe(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
