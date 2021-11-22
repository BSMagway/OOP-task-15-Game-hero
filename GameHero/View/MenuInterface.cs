using System;
using System.Collections.Generic;
using System.Text;

namespace GameHero.View
{
    public static class MenuInterface
    {
        public static void StartInSwitchMenuInterface(string heroInfo)
        {
            Console.Clear();
            HeroInfo.HeroInfoForMenu(heroInfo);
        }

        public static void FinishInSwitchMenuInterface()
        {
            Printer.Print("\nPress enter to continue ...");
            Console.ReadLine();
        }
    }
}
