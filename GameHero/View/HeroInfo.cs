using System;

namespace GameHero.View
{
    public static class HeroInfo
    {
        public static void HeroInfoForMenu(string info)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Printer.Print(info);
            Console.ResetColor();
        }

        public static void HeroFullInfoForMenu(string info)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Printer.Print(info);
            Console.ResetColor();
        }


    }
}
