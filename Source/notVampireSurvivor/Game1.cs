using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace notVampireSurvivor
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        SpriteFont font1;

        int sirkaOkna = 800;
        int vyskaOkna = 800;

        private Texture2D playerTexture;
        Player hrac;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            sirkaOkna = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            vyskaOkna = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            Debug.WriteLine($"sirka {sirkaOkna} vyska {vyskaOkna}");

            _graphics.PreferredBackBufferWidth = sirkaOkna;
            _graphics.PreferredBackBufferHeight = vyskaOkna;
            _graphics.ApplyChanges();
            _graphics.ToggleFullScreen();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            font1 = Content.Load<SpriteFont>("MyMenuFont");
            playerTexture = Content.Load<Texture2D>("Player");


            hrac = new Player(playerTexture, sirkaOkna, vyskaOkna);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hrac.Pohyb();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.DrawString(font1, $"X: {hrac.playerMovement.X}    Y: {hrac.playerMovement.Y}", new Vector2(0, 0), Color.White);
            hrac.vykresliSe(_spriteBatch, sirkaOkna, vyskaOkna);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
