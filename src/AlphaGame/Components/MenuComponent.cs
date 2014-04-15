using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AlphaGame.Framework;

namespace AlphaGame.Components
{
    public delegate void MenuItemCallback();

    class MenuComponent : IComponent
    {
        protected VariableService vars;
        protected Dictionary<string, MenuItemCallback> items;
        protected Color activeColor, inactiveColor;
        protected SpriteFont menuFont;
        protected Vector2 position;
        protected int menuIndex = 0;

        public MenuComponent(Game game, int x, int y, string font, Color activeColor, Color inactiveColor)
        {
            vars = ServiceExtensionMethods.GetService<VariableService>(game.Services);
            items = new Dictionary<string, MenuItemCallback>();
            menuFont = vars.Content.Load<SpriteFont>(font);
            position = new Vector2(x, y);
            this.activeColor = activeColor;
            this.inactiveColor = inactiveColor;
        }

        public void Add(string title, MenuItemCallback callback)
        {
            if (!items.ContainsKey(title))
            {
                items.Add(title, callback);
            }
        }

        public void Remove(string title)
        {
            if (items.ContainsKey(title))
            {
                items.Remove(title);
            }
        }

        public void Update(GameTime gameTime)
        {
            UpdateInput();
        }

        private void UpdateInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Down) && !vars.OldKeyboardState.IsKeyDown(Keys.Down))
            {
                menuIndex++;
                if (menuIndex == items.Count) menuIndex = 0;
            }
            else if (keyboardState.IsKeyDown(Keys.Up) && !vars.OldKeyboardState.IsKeyDown(Keys.Up))
            {
                menuIndex--;
                if (menuIndex < 0) menuIndex = items.Count - 1;
            }
            else if (keyboardState.IsKeyDown(Keys.Enter) && !vars.OldKeyboardState.IsKeyDown(Keys.Enter))
            {
                var key = items.Keys.ElementAt(menuIndex);
                items[key].Invoke();
            }

            vars.OldKeyboardState = keyboardState;
        }

        public void Draw(GameTime gameTime)
        {
            var key = items.Keys.ElementAt(menuIndex);
            var offsetY = 0;

            foreach (var item in items)
            {
                var activeKey = GetActiveMenuItemKey();
                var text = item.Key;
                var textSize = menuFont.MeasureString(text);
                var textX = position.X - (textSize.X / 2);
                var textY = position.Y + offsetY;
                var textColor = (text.Equals(activeKey)) ? activeColor : inactiveColor;

                offsetY += (int)textSize.Y;
                vars.SpriteBatch.DrawString(menuFont, text, new Vector2((int)textX, (int)textY), textColor);
            }
        }

        private string GetActiveMenuItemKey()
        {
            return items.Keys.ElementAt(menuIndex);
        }
    }
}
