using System;
using System.Collections.Generic;
using System.Text;
using GameHero.Model.Data;
using GameHero.Model;
using GameHero.Model.StrategyPattern;
using GameHero.Model.Data.Artefact;
using GameHero.Model.StrategyPattern.Search;
using GameHero.View;

namespace GameHero.Controller
{
    public static class SwitchController
    {
        public static void HeroInfoSwitch(Hero hero)
        {
            MenuInterface.StartInSwitchMenuInterface(hero.ToString());
            HeroInfo.HeroFullInfoForMenu(hero.HeroInfo());
            MenuInterface.FinishInSwitchMenuInterface();
        }

        public static void HeroDungeonSwitch(Hero hero, Dungeon dungeon)
        {
            MenuInterface.StartInSwitchMenuInterface(hero.ToString());
            Menu.DungeonMenu();
            Printer.Print("\nHero enter key: ");
            string key = Console.ReadLine();
            dungeon.CurrentLevelDungeon = int.Parse(key);
            Console.Clear();
            HeroInfo.HeroInfoForMenu(hero.ToString());
            BattleLogic.BattleHeroWithMonstr(hero, MonstrLogic.GenerateRandomMonstr(dungeon.CurrentLevelDungeon), dungeon);
            MenuInterface.FinishInSwitchMenuInterface();
        }

        public static void HeroShopSwitch(Hero hero, Dungeon dungeon)
        {
            MenuInterface.StartInSwitchMenuInterface(hero.ToString());
            ArtefactShopLogic.SellArtefactsInShop(dungeon, hero, ArtefactsShop.GetInstance());
            MenuInterface.FinishInSwitchMenuInterface();
        }

        public static void HeroInnSwitch(Hero hero)
        {
            MenuInterface.StartInSwitchMenuInterface(hero.ToString());
            Printer.Print($"\n\n{hero.Name} rest in {Inn.GetInctance().ToString()}");
            InnLogic.InnRestForFullRestore(hero);
            MenuInterface.FinishInSwitchMenuInterface();
        }

        public static void DefaultSwitch(Hero hero)
        {
            MenuInterface.StartInSwitchMenuInterface(hero.ToString());
            Printer.Print("\n\nEnter wrong key. ");
            MenuInterface.FinishInSwitchMenuInterface();
        }

        public static void HeroInventorySort(Hero hero)
        {
            MenuInterface.StartInSwitchMenuInterface(hero.ToString());
            Printer.Print("\nSort hero inventory: ");
            Menu.SortHeroInventory();
            Printer.Print("\nHero enter key: ");
            string key = Console.ReadLine();
            ArtefactList<Artefact> result;

            switch (key)
            {
                case "0":
                    result = HeroLogic.GetInctance().HeroInventorySort(hero, (art1, art2) => art1.Strength > art2.Strength);
                    Printer.Print($"\nHero artefacts sorted by strenght (ascend): {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "1":
                    result = HeroLogic.GetInctance().HeroInventorySort(hero, (art1, art2) => art1.Intellect > art2.Intellect);
                    Printer.Print($"\nHero artefacts sorted by intellect (ascend): {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "2":
                    result = HeroLogic.GetInctance().HeroInventorySort(hero, (art1, art2) => art1.Constitution > art2.Constitution);
                    Printer.Print($"\nHero artefacts sorted by constitution (ascend): {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "3":
                    result = HeroLogic.GetInctance().HeroInventorySort(hero, (art1, art2) => art1.Constitution > art2.Constitution);
                    Printer.Print($"\nHero artefacts sorted by dexterity (ascend): {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "4":
                    result = HeroLogic.GetInctance().HeroInventorySort(hero, (art1, art2) => art1.Price > art2.Price);
                    Printer.Print($"\nHero artefacts sorted by price (ascend): {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "5":
                    result = HeroLogic.GetInctance().HeroInventorySort(hero, delegate (Artefact art1, Artefact art2) { return art1.Strength < art2.Strength; });
                    Printer.Print($"\nHero artefacts sorted by strenght (descend): {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "6":
                    result = HeroLogic.GetInctance().HeroInventorySort(hero, delegate (Artefact art1, Artefact art2) { return art1.Intellect < art2.Intellect; });
                    Printer.Print($"\nHero artefacts sorted by intellect (descend): {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "7":
                    result = HeroLogic.GetInctance().HeroInventorySort(hero, delegate (Artefact art1, Artefact art2) { return art1.Constitution < art2.Constitution; });
                    Printer.Print($"\nHero artefacts sorted by constitution (descend): {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "8":
                    result = HeroLogic.GetInctance().HeroInventorySort(hero, delegate (Artefact art1, Artefact art2) { return art1.Dexterity < art2.Dexterity; });
                    Printer.Print($"\nHero artefacts sorted by dexterity (descend): {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "9":
                    result = HeroLogic.GetInctance().HeroInventorySort(hero, delegate (Artefact art1, Artefact art2) { return art1.Price < art2.Price; });
                    Printer.Print($"\nHero artefacts sorted by price (descend): {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                default:
                    Printer.Print("\n\nEnter wrong key. ");
                    break;
            }

            MenuInterface.FinishInSwitchMenuInterface();
        }

        public static void HeroInventorySearch(Hero hero)
        {
            MenuInterface.StartInSwitchMenuInterface(hero.ToString());
            Printer.Print("\nSearch in hero inventory: ");
            Menu.SerchIntHeroInventory();
            Printer.Print("\nHero enter key: ");
            string key = Console.ReadLine();
            ArtefactList<Artefact> result;
            int predicateInt;
            string predicateString;

            switch (key)
            {
                case "0":
                    Printer.Print($"\nEnter strength: ");
                    predicateInt = int.Parse(Console.ReadLine());
                    result = HeroLogic.GetInctance().HeroInventorySearch<int>(hero, predicateInt, (art, predicate) => art.Strength == predicate);
                    Printer.Print($"\nHero artefacts search by strenght: {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "1":
                    Printer.Print($"\nEnter intellect: ");
                    predicateInt = int.Parse(Console.ReadLine());
                    result = HeroLogic.GetInctance().HeroInventorySearch<int>(hero, predicateInt, (art, predicate) => art.Intellect == predicate);
                    Printer.Print($"\nHero artefacts search by intellect: {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "2":
                    Printer.Print($"\nEnter constitution: ");
                    predicateInt = int.Parse(Console.ReadLine());
                    result = HeroLogic.GetInctance().HeroInventorySearch<int>(hero, predicateInt, (art, predicate) => art.Constitution == predicate);
                    Printer.Print($"\nHero artefacts search by constitution: {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "3":
                    Printer.Print($"\nEnter dexterity: ");
                    predicateInt = int.Parse(Console.ReadLine());
                    result = HeroLogic.GetInctance().HeroInventorySearch<int>(hero, predicateInt, delegate (Artefact art, int predicate) { return art.Dexterity == predicate; });
                    Printer.Print($"\nHero artefacts search by dexterity: {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "4":
                    Printer.Print($"\nEnter price: ");
                    predicateInt = int.Parse(Console.ReadLine());
                    result = HeroLogic.GetInctance().HeroInventorySearch<int>(hero, predicateInt, delegate (Artefact art, int predicate) { return art.Price == predicate; });
                    Printer.Print($"\nHero artefacts search by price: {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;
                case "5":
                    Printer.Print($"\nEnter name: ");
                    predicateString =Console.ReadLine();
                    result = HeroLogic.GetInctance().HeroInventorySearch<string>(hero, predicateString, delegate (Artefact art, string predicate) { return art.Name == predicate; });
                    Printer.Print($"\nHero artefacts search by name: {ArtefactLogic.InfoAboutArtefactsList(result)}");
                    break;

                default:
                    Printer.Print("\n\nEnter wrong key. ");
                    break;
            }

            MenuInterface.FinishInSwitchMenuInterface();
        }

    }
}
