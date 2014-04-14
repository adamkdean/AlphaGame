using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace AlphaGame.Framework
{
    public class VariableService
    {
        public Game Game { get; set; }
        public GraphicsDeviceManager Graphics { get; set; }
        public GraphicsDevice GraphicsDevice { get; set; }
        public ContentManager Content { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public IScreen CurrentScreen { get; set; }
        //public KeyboardState CurrentKeyboardState { get; set; }
        public KeyboardState OldKeyboardState { get; set; }

        public int DisplayWidth
        {
            get
            {
                return GraphicsDevice.Viewport.Width;
            }
        }

        public int DisplayHeight
        {
            get
            {
                return GraphicsDevice.Viewport.Height;
            }
        }
    }
}