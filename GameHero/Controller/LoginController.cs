using GameHero.Model;
using GameHero.Model.Data;
using GameHero.View;
using System;

namespace GameHero.Controller
{
    class LoginController
    {
        public static Hero LoginUser()
        {
            Menu.LoginMenu();
            string key;
            Printer.Print("\nHero enter key: ");
            Hero hero = null;
            key = Console.ReadLine();

            switch (key)
            {
                case "1":
                    hero = LoginLogic.CreateHero();
                    break;
                case "2":
                    hero = LoginLogic.LoadHero();
                    break;
                case "3":
                    hero = LoginLogic.LoginDefaultHero();
                    break;
                default:
                    Printer.Print("\n\nEnter wrong key. ");
                    break;
            }

            return hero;
        }

    }
}
