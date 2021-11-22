using System;
using GameHero.Model.Data.Artefact;
using GameHero.Model.Data;
using GameHero.Model;
using GameHero.View;

namespace GameHero
{
    class Program
    {
        static void Main(string[] args)
        {
            bool operatorOnOff = true;
            Hero hero = new Hero("Test hero", 4, 3, 6, 7, 300);
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
                        operatorOnOff = false;
                        break;
                    default:
                        Controller.SwitchController.DefaultSwitch(hero);
                        break;
                }

            }

                //Hero hero = new Hero();

                //Neck neck = new Neck("neck1", 5, 6, 7, 8, 100);
                //Ring ring = new Ring("ring1", 4, 2, 1, 0, 140);
                //Orb orb = new Orb("orb1", 6, 8, 0, 0, 120);

                //hero.AddArtefact(neck);
                //hero.AddArtefact(ring);
                //hero.AddArtefact(orb);

                //Printer.Print(hero.HeroInfo());



                //Console.WriteLine(hero);
                //Console.WriteLine(HeroLogic.GetInctance().CountSumArtefactsPrice(hero));

                //Neck neck = new Neck("neck1", 5, 6, 7, 8, 100);
                //Ring ring = new Ring("ring1", 4, 2, 1, 0, 140);
                //Orb orb = new Orb("orb1", 6, 8, 0, 0, 120);

                //hero.AddArtefact(neck);
                //hero.AddArtefact(ring);
                //hero.AddArtefact(orb);

                //Console.WriteLine(hero);
                //Console.WriteLine(HeroLogic.GetInctance().CountSumArtefactsPrice(hero));



            }
    }
}
