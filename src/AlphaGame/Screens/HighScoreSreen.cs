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
    class HighScoreScreen : IScreen
    {
        private VariableService vars;
        private SpriteFont titleFont;
        private Texture2D background;
        private MenuComponent menu;

        public HighScoreScreen(Game game)
        {
            vars = ServiceExtensionMethods.GetService<VariableService>(game.Services);
            LoadContent();
        }

        private void LoadContent()
        {
            menu = new MenuComponent(vars.Game,
                x: vars.GraphicsDevice.Viewport.Width / 2,
                y: vars.GraphicsDevice.Viewport.Height - (vars.GraphicsDevice.Viewport.Height/5),
                inactiveColor: Color.White,
                activeColor: Color.Yellow,
                font: "Fonts/menu");

            menu.Add("GO BACK", new MenuItemCallback(GoBack));

            background = vars.Content.Load<Texture2D>("Artwork/background");
            titleFont = vars.Content.Load<SpriteFont>("Fonts/title");
        }

        private void GoBack()
        {
            vars.CurrentScreen = new TitleScreen(vars.Game);
        }

        public void Update(GameTime gameTime)
        {
            menu.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            vars.GraphicsDevice.Clear(Color.Black);
            vars.SpriteBatch.Begin();
            DrawBackground();
            DrawTitleText();
            menu.Draw(gameTime);
            vars.SpriteBatch.End();
        }

        private void DrawBackground()
        {
            vars.SpriteBatch.Draw(background, new Rectangle(0, 0, vars.DisplayWidth, vars.DisplayHeight), Color.White);
        }

        private void DrawTitleText()
        {
            var text = "High Scores";
            var textSize = titleFont.MeasureString(text);
            var x = vars.GraphicsDevice.Viewport.Width / 2 - (int)textSize.X / 2;
            var y = vars.GraphicsDevice.Viewport.Height / 5 - (int)textSize.Y / 2;

            vars.SpriteBatch.DrawString(titleFont, text, new Vector2(x, y), Color.White);
        }
    }
}