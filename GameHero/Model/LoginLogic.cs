using System;
using System.Collections.Generic;
using GameHero.Model.Data;
using GameHero.Model.IO;
using GameHero.Model.IO.Implementation;
using GameHero.View;

namespace GameHero.Model
{
    public static class LoginLogic
    {
        private const string DEFAULT_HERO_NAME = "Hero";

        public static void CreateDefaultSave()
        {
            ISaveLoadLogin loadSaveLogin = new SaveLoadLogin();
            IList<Login> heroList = loadSaveLogin.Read();

            if (heroList.Count == 0)
            {
                Hero hero = new Hero();
                ISaveLoadHero saveLoadHero = new SaveLoadHero();
                saveLoadHero.Write(hero);
                heroList.Add(new Login(DEFAULT_HERO_NAME));
                loadSaveLogin.Write(heroList);
            }
        }

        public static bool LoginEquals(IList<Login> logins, string heroName)
        {
            foreach (Login item in logins)
            {
                if (item.UserLogin == heroName)
                {
                    return true;
                }
            }

            return false;
        }

        public static IList<Login> LoadLoginList()
        {

            ISaveLoadLogin loadSaveLogin = new SaveLoadLogin();
            IList<Login> heroList = loadSaveLogin.Read();

            if (heroList.Count == 0)
            {
                CreateDefaultSave();
                heroList = loadSaveLogin.Read();
            }

            return heroList;
        }


        public static Hero CreateHero()
        {
            IList<Login> heroList = LoadLoginList();

            bool operationCreation = true;
            Hero hero = new Hero();

            while (operationCreation)
            {
                Console.Clear();
                Printer.Print("Enter new hero name (one word): ");
                string newName = Console.ReadLine();

                if (!LoginEquals(heroList, newName))
                {
                    hero.Name = newName;
                    heroList.Add(new Login(newName));
                    operationCreation = false;
                }
                else
                {
                    Printer.Print("Hero with entered name exist.");
                    MenuInterface.FinishInSwitchMenuInterface();
                }
            }

            ISaveLoadLogin loadSaveLogin = new SaveLoadLogin();
            loadSaveLogin.Write(heroList);

            return hero;
        }

        public static Hero LoadHero()
        {
            IList<Login> heroList = LoadLoginList();

            ISaveLoadHero saveLoadHero = new SaveLoadHero();
            Hero hero = null;

            bool operationCreation = true;

            while (operationCreation)
            {
                Console.Clear();
                Printer.Print("Enter exist hero name (one word): ");
                string heroName = Console.ReadLine();

                if (LoginEquals(heroList, heroName) && heroName != DEFAULT_HERO_NAME)
                {
                    hero = saveLoadHero.Read(heroName);
                    operationCreation = false;
                }
                else
                {
                    Printer.Print("Hero with entered name don't exist.");
                    MenuInterface.FinishInSwitchMenuInterface();
                }
            }

            ISaveLoadLogin loadSaveLogin = new SaveLoadLogin();
            loadSaveLogin.Write(heroList);

            return hero;
        }

        public static Hero LoginDefaultHero()
        {
            CreateDefaultSave();

            ISaveLoadHero saveLoadHero = new SaveLoadHero();
            Hero hero = saveLoadHero.Read(DEFAULT_HERO_NAME);

            return hero;
        }
    }
}
