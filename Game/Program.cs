using System;
/*
 * Names: Zawn Zachow,
 * Project: Tangram Trouble
 */
namespace TangramTrouble
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
