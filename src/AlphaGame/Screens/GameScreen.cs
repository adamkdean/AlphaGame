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
        private Texture2D background;
        
        public GameScreen(Game game)
        {
            vars = ServiceExtensionMethods.GetService<VariableService>(game.Services);
            LoadContent();
        }

        private void LoadContent()
        {
            background = vars.Content.Load<Texture2D>("Artwork/background");
        }

        public void Update(GameTime gameTime)
        {
            //
        }

        public void Draw(GameTime gameTime)
        {
            vars.GraphicsDevice.Clear(Color.Black);
            vars.SpriteBatch.Begin();
            DrawBackground();
            vars.SpriteBatch.End();
        }

        private void DrawBackground()
        {
            vars.SpriteBatch.Draw(background, new Rectangle(0, 0, vars.DisplayWidth, vars.DisplayHeight), Color.White);
        }
    }
}