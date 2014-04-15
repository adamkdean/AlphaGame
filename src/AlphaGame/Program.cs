using System;
using System.Collections.Generic;
using System.Linq;

namespace AlphaGame
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new AlphaGame())
            {
                game.Run();
            }
        }
    }
#endif
}