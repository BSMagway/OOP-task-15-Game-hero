using System;
using System.Collections.Generic;
using System.Text;
using GameHero.Model.Data;
using GameHero.Model.Data.Artefact;
using GameHero.Model.StrategyPattern;
using GameHero.Model.StrategyPattern.Search;
using GameHero.View;

namespace GameHero.Model
{
    public class HeroLogic
    {
        private const int EVADE_CHANCE_RANDOM = 100;
        private static HeroLogic heroLogic;

        private HeroLogic()
        {

        }

        public static HeroLogic GetInctance()
        {
            if (heroLogic is null)
            {
                heroLogic = new HeroLogic();
            }

            return heroLogic;
        }

        public int CountSumArtefactsPrice(Hero hero)
        {
            if (hero is null)
            {
                throw new ArgumentNullException($"{nameof(hero)} is null");
            }

            int result = 0;

            foreach (Artefact item in hero.HeroArtefacts)
            {
                result += item.Price;
            }

            return result;
        }

        public bool CountEvadeTrueOrFalse(int heroEvade)
        {
            bool result = false;

            Random randomEvade = new Random();
            if (heroEvade >= randomEvade.Next(EVADE_CHANCE_RANDOM))
            {
                result = true;
            }

            return result;
        }

        public void HeroFullRestoreHealthAndMana(Hero hero)
        {
            if (hero is null)
            {
                throw new ArgumentNullException($"{nameof(hero)} is null");
            }

            if (hero.CurrentHealth < hero.FullHealth)
            {
                hero.SetCurrentHealthToFullHealth();
            }

            if (hero.CurrentMana < hero.FullMana)
            {
                hero.SetCurrentManaToFullMana();
            }
        }

        public List<Artefact> HeroInventorySort(Hero hero, ICompareArtefacts compareArtefacts)
        {
            List<Artefact> sortedInventory = new List<Artefact>();

            foreach (Artefact item in hero.HeroArtefacts)
            {
                sortedInventory.Add(item);
            }

            for (int i = 0; i < (sortedInventory.Count - 1); i++)
            {
                for (int j = i + 1; j < sortedInventory.Count; j++)
                {
                    if (compareArtefacts.Compare(sortedInventory[i], sortedInventory[j]))
                    {
                        Artefact temp = sortedInventory[i];
                        sortedInventory[i] = sortedInventory[j];
                        sortedInventory[j] = temp;
                    }
                }
            }

            return sortedInventory;
        }

        public List<Artefact> HeroInventorySearch<T>(Hero hero, ISearchArtefacts<T> searchArtefacts, T predicate)
        {
            List<Artefact> searchInInventory = new List<Artefact>();

            foreach (Artefact item in hero.HeroArtefacts)
            {
                if (searchArtefacts.Predicate(item, predicate))
                {
                    searchInInventory.Add(item);
                }
            }

            return searchInInventory;
        }
    }
}
