using Microsoft.Xna.Framework;

namespace AlphaGame.Framework
{
    public interface IScreen
    {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}