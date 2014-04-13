using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using AlphaGame.Framework;

namespace AlphaGame
{
    public class AlphaGame : Game
    {
        private GraphicsDeviceManager graphics;
        private VariableService vars;

        public AlphaGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ServiceExtensionMethods.AddService<VariableService>(this.Services, new VariableService());
            vars = ServiceExtensionMethods.GetService<VariableService>(this.Services);
            vars.Game = this;
            vars.Content = Content;
            vars.Graphics = graphics;
            vars.GraphicsDevice = graphics.GraphicsDevice;
            vars.SpriteBatch = new SpriteBatch(GraphicsDevice);
            vars.CurrentScreen = new TitleScreen(this);

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //
        }

        protected override void Update(GameTime gameTime)
        {
            vars.CurrentScreen.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            vars.CurrentScreen.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
