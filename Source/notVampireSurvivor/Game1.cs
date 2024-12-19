using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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


        BackgroundManager background;
        Texture2D playerTexture;

        List<SlimeEnemy> slimeEnemyList;
        Texture2D slimeTexture;
        int pocetSlimeEnemy = 1;

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
            _graphics.ToggleFullScreen();
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            font1 = Content.Load<SpriteFont>("MyMenuFont");

            playerTexture = Content.Load<Texture2D>("Player");
            slimeTexture = Content.Load<Texture2D>("slimeEnemy");

            Texture2D[] textures = new[] {
                                        Content.Load<Texture2D>("background"),
                                        Content.Load<Texture2D>("background2"),
                                        };

            background = new BackgroundManager(_spriteBatch,
                                               textures,
                                               GraphicsDevice.Viewport.Width,
                                               GraphicsDevice.Viewport.Height);

            hrac = new Player(playerTexture, sirkaOkna, vyskaOkna);

            //Adds slime enemies
            slimeEnemyList = new List<SlimeEnemy>();
            for (int i = 0; i < pocetSlimeEnemy; i++)
            {
                slimeEnemyList.Add(new SlimeEnemy(slimeTexture));
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hrac.Pohyb(Keys.W, Keys.S, Keys.A, Keys.D);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                          SamplerState.LinearWrap, null, null);

            background.Draw(hrac.playerMovement);

            _spriteBatch.DrawString(font1, $"X: {hrac.playerMovement.X}    Y: {hrac.playerMovement.Y}", new Vector2(0, 0), Color.White);
            hrac.vykresliSe(_spriteBatch, sirkaOkna, vyskaOkna);

            foreach(SlimeEnemy s in slimeEnemyList)
            {
                s.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
