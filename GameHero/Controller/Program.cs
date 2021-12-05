using System;
using GameHero.Model.Data;
using GameHero.View;
using GameHero.Controller;
using GameHero.Model.IO;
using GameHero.Model.IO.Implementation;

namespace GameHero
{
    class Program
    {
        static void Main(string[] args)
        {
            bool operatorOnOff = true;

            Hero hero = LoginController.LoginUser();
            Dungeon dungeon = new Dungeon();


            while (operatorOnOff)
            {
                string key;
                Console.Clear();
                HeroInfo.HeroInfoForMenu(hero.ToString());
                Menu.StartMenu();
                Printer.Print("\nHero enter key: ");
                key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        Controller.SwitchController.HeroInfoSwitch(hero);
                        break;
                    case "2":
                        Controller.SwitchController.HeroDungeonSwitch(hero, dungeon);
                        break;
                    case "3":
                        Controller.SwitchController.HeroShopSwitch(hero, dungeon);
                        break;
                    case "4":
                        Controller.SwitchController.HeroInnSwitch(hero);
                        break;
                    case "5":
                        Controller.SwitchController.HeroInventorySort(hero);
                        break;
                    case "6":
                        Controller.SwitchController.HeroInventorySearch(hero);
                        break;
                    case "9":
                        ISaveLoadHero saveLoadHero = new SaveLoadHero();
                        saveLoadHero.Write(hero);
                        operatorOnOff = false;
                        break;
                    default:
                        Controller.SwitchController.DefaultSwitch(hero);
                        break;
                }

            }
        }
    }
}
