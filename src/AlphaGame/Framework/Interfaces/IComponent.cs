using Microsoft.Xna.Framework;

namespace AlphaGame.Framework
{
    public interface IComponent
    {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}