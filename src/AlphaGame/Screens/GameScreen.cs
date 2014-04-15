using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using AlphaGame.Components;

namespace AlphaGame.Framework
{
    class GameScreen : IScreen
    {
        private VariableService vars;
        private Texture2D background, sand, ship;
        private GridComponent grid;
        
        public GameScreen(Game game)
        {
            vars = ServiceExtensionMethods.GetService<VariableService>(game.Services);
            LoadContent();
            InitialiseGame();
        }

        private void LoadContent()
        {
            background = vars.Content.Load<Texture2D>("Artwork/background");
            sand = vars.Content.Load<Texture2D>("Artwork/sand");
            ship = vars.Content.Load<Texture2D>("Artwork/ship");
        }

        private void InitialiseGame()
        {
            grid = new GridComponent(vars.Game, 32, sand);
        }

        public void Update(GameTime gameTime)
        {
            grid.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            vars.GraphicsDevice.Clear(Color.Black);
            vars.SpriteBatch.Begin();
            DrawBackground();
            grid.Draw(gameTime);
            vars.SpriteBatch.End();
        }

        private void DrawBackground()
        {
            vars.SpriteBatch.Draw(background, new Rectangle(0, 0, vars.DisplayWidth, vars.DisplayHeight), Color.White);
        }
    }
}