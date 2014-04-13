using Microsoft.Xna.Framework;

namespace AlphaGame.Framework
{
    static class ServiceExtensionMethods
    {
        public static void AddService<T> (this GameServiceContainer services, T service)
        {
            services.AddService(typeof(T), service);
        }

        public static T GetService<T>(this GameServiceContainer services)
        {
            return (T)services.GetService(typeof(T));
        }
    }
}