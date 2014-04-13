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

namespace AlphaGame.Framework
{
    class TitleScreen : IScreen
    {
        private VariableService vars;
        private Texture2D background;

        public TitleScreen(Game game)
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
            // to change screen, simply
            // vars.CurrentScreen = new TestScreen(vars.Game);
        }

        public void Draw(GameTime gameTime)
        {
            vars.GraphicsDevice.Clear(Color.Black);

            vars.SpriteBatch.Begin();
            vars.SpriteBatch.Draw(background, new Rectangle(0, 0, vars.DisplayWidth, vars.DisplayHeight), Color.White);
            vars.SpriteBatch.End();
        }
    }
}