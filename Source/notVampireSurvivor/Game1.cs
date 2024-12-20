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

        int sirkaOkna;
        int vyskaOkna;
        int nejdelsiStranaOkna;

        BackgroundManager background;
        Texture2D playerTexture;

        List<SlimeEnemy> slimeEnemyList;
        Texture2D slimeTexture;
        int pocetSlimeEnemy = 10;
        Vector2 WorldOrigin;

        Player hrac;
        MouseState mouse;

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
            if (sirkaOkna >= vyskaOkna)
                nejdelsiStranaOkna = sirkaOkna;
            else
                nejdelsiStranaOkna = vyskaOkna;

            WorldOrigin = new Vector2(sirkaOkna/2, vyskaOkna/2);

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

            hrac = new Player(playerTexture, sirkaOkna, vyskaOkna, WorldOrigin);

            //Adds slime enemies
            slimeEnemyList = new List<SlimeEnemy>();
            List<Vector2> listOfSpawnPoints = GetPointsOnCircle(nejdelsiStranaOkna/2, pocetSlimeEnemy, new Vector2(hrac.playerMovement.X + sirkaOkna/2, hrac.playerMovement.Y + vyskaOkna/2));

            for (int i = 0; i < pocetSlimeEnemy; i++)
            {
                slimeEnemyList.Add(new SlimeEnemy(slimeTexture, hrac, new Vector2(listOfSpawnPoints[i].X, listOfSpawnPoints[i].Y)));
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hrac.Pohyb(Keys.W, Keys.S, Keys.A, Keys.D);

            mouse = Mouse.GetState();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                          SamplerState.LinearWrap, null, null);

            background.Draw(hrac.playerMovement);

            hrac.vykresliSe(_spriteBatch, sirkaOkna, vyskaOkna);

            foreach(SlimeEnemy s in slimeEnemyList)
            {
                s.Draw(_spriteBatch, hrac);
            }

            // draws square at world origin (0,0)
            Rect rect = new Rect(WorldOrigin, hrac, GraphicsDevice, 15, 15, Color.Orange);
            rect.Draw(_spriteBatch, hrac);

            Rect Smolrect = new Rect(WorldOrigin, hrac, GraphicsDevice, 5, 5, Color.Red);
            Smolrect.Draw(_spriteBatch, hrac);
            // // // // // // // // // // //

            _spriteBatch.DrawString(font1, $"Player movement: {hrac.playerMovement.X}  {hrac.playerMovement.Y}", new Vector2(0, 0), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
            _spriteBatch.DrawString(font1, $"MOUSE CORDS (TOWARD CORNER OF SCREEN): {mouse.X}    Y: {mouse.Y}", new Vector2(mouse.X + 5, mouse.Y - 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
            _spriteBatch.DrawString(font1, $"X: {-(sirkaOkna/2 - mouse.X)}    Y: {-(vyskaOkna/2 - mouse.Y)}", new Vector2(mouse.X + 5, mouse.Y - 15), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
            //_spriteBatch.DrawString(font1, $"X: {mouse.X - hrac.playerMovement.X}    Y: {mouse.Y - hrac.playerMovement.Y}", new Vector2(mouse.X + 5, mouse.Y - 15), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public static List<Vector2> GetPointsOnCircle(float radius, int numberOfPoints, Vector2 center)
        {
            if (numberOfPoints <= 0)
            {
                throw new System.ArgumentException("Number of points must be positive", nameof(numberOfPoints));
            }

            if (radius <= 0)
            {
                throw new System.ArgumentException("Radius must be positive", nameof(radius));
            }

            var points = new List<Vector2>(numberOfPoints);

            // Calculate the angle between each point
            float angleStep = (float)(2f * Math.PI / numberOfPoints);

            for (int i = 0; i < numberOfPoints; i++)
            {
                float angle = i * angleStep;
                float x = (float)(center.X + radius * Math.Cos(angle));
                float y = (float)(center.Y + radius * Math.Sin(angle));
                points.Add(new Vector2(x, y));
            }

            return points;
        }

        internal static void SpawnSlimeEnemies(int nejdelsiStranaOkna, int pocet, int sirkaOkna, int vyskaOkna, Player hrac, Texture2D slimeTexture)
        {
            //Adds slime enemies
            List<SlimeEnemy> slimeEnemyList = new List<SlimeEnemy>();
            List<Vector2> listOfSpawnPoints = GetPointsOnCircle(nejdelsiStranaOkna / 2, pocet, new Vector2(hrac.playerMovement.X + sirkaOkna / 2, hrac.playerMovement.Y + vyskaOkna / 2));

            for (int i = 0; i < pocet; i++)
            {
                slimeEnemyList.Add(new SlimeEnemy(slimeTexture, hrac, new Vector2(listOfSpawnPoints[i].X, listOfSpawnPoints[i].Y)));
            }
        }
    }
}
