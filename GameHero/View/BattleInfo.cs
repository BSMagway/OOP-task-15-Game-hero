using System;
using System.Collections.Generic;
using System.Text;

namespace GameHero.View
{
    public static class BattleInfo
    {
        public static void BattleInfoHeroHit(string info)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Printer.Print(info);
            Console.ResetColor();
        }

        public static void BattleInfoHeroEvade(string info)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Printer.Print(info);
            Console.ResetColor();
        }

        public static void BattleInfoMonstrHit(string info)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Printer.Print(info);
            Console.ResetColor();
        }

        public static void BattleInfoMonstrEvade(string info)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Printer.Print(info);
            Console.ResetColor();
        }
    }
}
