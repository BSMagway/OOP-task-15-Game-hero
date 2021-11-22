using System;
using System.Collections.Generic;
using System.Text;

namespace GameHero.View
{
    public static class Menu
    {
        public static void StartMenu()
        {
            Printer.Print("\n\n1 - show full info about hero");
            Printer.Print("\n2 - go to dungeon");
            Printer.Print("\n3 - go to shop");
            Printer.Print("\n4 - go to inn (restore full health and mana)");
            Printer.Print("\n5 - show sort inventory");
            Printer.Print("\n6 - search artefacts in inventory");
            Printer.Print("\n9 - quit");
        }

        public static void DungeonMenu()
        {
            Printer.Print("\n\n1 - go to 1 floor (monstr 1 - 2 lvl)");
            Printer.Print("\n2 - go to 2 floor (monstr 3 - 4 lvl)");
            Printer.Print("\n3 - go to 3 floor (monstr 5 - 6 lvl)");
            Printer.Print("\n4 - go to 4 floor (monstr 7 - 8 lvl)");
            Printer.Print("\n5 - go to 5 floor (monstr 9 - 10 lvl)");
            Printer.Print("\n6 - back");
        }

        public static void SortHeroInventory()
        {
            Printer.Print("\n\n0 - sort by strength ascend");
            Printer.Print("\n1 - sort by intellect ascend");
            Printer.Print("\n2 - sort by constitution ascend");
            Printer.Print("\n3 - sort by dexterity ascend");
            Printer.Print("\n4 - sort by price ascend");
            Printer.Print("\n5 - sort by strength descend");
            Printer.Print("\n6 - sort by intellect descend");
            Printer.Print("\n7 - sort by constitution descend");
            Printer.Print("\n8 - sort by dexterity descend");
            Printer.Print("\n9 - sort by price descend");
        }

        public static void SerchIntHeroInventory()
        {
            Printer.Print("\n\n0 - search by strength");
            Printer.Print("\n1 - search by intellect");
            Printer.Print("\n2 - search by constitution");
            Printer.Print("\n3 - search by dexterity");
            Printer.Print("\n4 - search by price");
            Printer.Print("\n5 - search by name");

        }

    }
}
