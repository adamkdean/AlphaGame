using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AlphaGame.Framework;

namespace AlphaGame.Components
{
    public delegate void MenuItemCallback();

    class MenuComponent : IComponent
    {
        private VariableService vars;
        private SpriteFont menuFont;
        private Vector2 position;
        private Dictionary<string, MenuItemCallback> items;
        private int margin;

        public MenuComponent(Game game, int x, int y, string font, int margin = 10)
        {
            vars = ServiceExtensionMethods.GetService<VariableService>(game.Services);
            items = new Dictionary<string, MenuItemCallback>();
            menuFont = vars.Content.Load<SpriteFont>(font);
            position = new Vector2(x, y);
            this.margin = margin;
        }

        public void Add(string title, MenuItemCallback callback)
        {
            if (!items.ContainsKey(title)) 
                items.Add(title, callback);
        }

        public void Remove(string title)
        {
            if (items.ContainsKey(title))
                items.Remove(title);
        }

        public void Update(GameTime gameTime)
        {
            //
        }

        public void Draw(GameTime gameTime)
        {
            var menuHeight = GetMenuHeight();
            var menuStartY = position.Y - (menuHeight / 2);
            var offsetY = margin / 2;

            foreach (var item in items)
            {
                var text = item.Key;
                var textSize = menuFont.MeasureString(text);
                var textX = position.X - (textSize.X / 2);
                var textY = menuStartY + offsetY - (textSize.Y / 2);
                offsetY += margin + ((int)textSize.Y / 2);
                vars.SpriteBatch.DrawString(menuFont, text, new Vector2(textX, textY), Color.White);
            }


        }

        private float GetMenuHeight()
        {
            var totalHeight = 0f;
            foreach (var item in items)
            {
                totalHeight += menuFont.MeasureString(item.Key).Y + (float)this.margin;
            }
            return totalHeight;
        }
    }
}
