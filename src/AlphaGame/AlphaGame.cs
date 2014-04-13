using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace AlphaGame
{
    public class AlphaGame : Game
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        private Texture2D background, sand, ship;

        private int DisplayWidth
        {
            get
            {
                return this.graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            }
        }

        private int DisplayHeight
        {
            get
            {
                return this.graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            }
        }

        public AlphaGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = this.Content.Load<Texture2D>("Artwork/background");
            sand = this.Content.Load<Texture2D>("Artwork/sand");
            ship = this.Content.Load<Texture2D>("Artwork/ship");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, DisplayWidth, DisplayHeight), Color.White);
            spriteBatch.Draw(sand, new Rectangle(100, 100, 20, 20), Color.White);
            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
