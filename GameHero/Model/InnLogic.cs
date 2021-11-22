using System;
using System.Collections.Generic;
using System.Text;
using GameHero.Model.Data;
using GameHero.View;

namespace GameHero.Model
{
    public static class InnLogic
    {
        public static void InnRestForFullRestore(Hero hero)
        {
            if (hero is null)
            {
                throw new ArgumentNullException($"{nameof(hero)} is null");
            }

            if (hero.SetMoneyOutcome(Inn.GetInctance().PriceRest))
            {
                HeroLogic.GetInctance().HeroFullRestoreHealthAndMana(hero);
                Printer.Print("\nHealth and mana are full.");
            }
            else
            {
                Printer.Print("\nDon't have enough money.");
            }
        }
    }
}
