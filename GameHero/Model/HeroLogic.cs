using System;
using GameHero.Model.Data;
using GameHero.Model.Data.Artefact;

namespace GameHero.Model
{
    public delegate bool SortAtributeDelegate(Artefact a1, Artefact a2);
    public delegate bool SearchArthefactsDelegate<T>(Artefact a1, T predicate);
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

            foreach (Artefact item in hero.ArtefactList)
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

        public ArtefactList<Artefact> HeroInventorySort(Hero hero, SortAtributeDelegate sortAtributeDelegate)
        {
            ArtefactList<Artefact> sortedInventory = new ArtefactList<Artefact>();

            foreach (Artefact item in hero.ArtefactList)
            {
                sortedInventory.AddArtefact(item);
            }

            for (int i = 0; i < (sortedInventory.Size() - 1); i++)
            {
                for (int j = i + 1; j < sortedInventory.Size(); j++)
                {
                    if (sortAtributeDelegate(sortedInventory[i], sortedInventory[j]))
                    {
                        Artefact temp = sortedInventory[i];
                        sortedInventory[i] = sortedInventory[j];
                        sortedInventory[j] = temp;
                    }
                }
            }

            return sortedInventory;
        }

        public ArtefactList<Artefact> HeroInventorySearch<T>(Hero hero, T predicate, SearchArthefactsDelegate<T> searchArthefactsDelegate)
        {
            ArtefactList<Artefact> searchInInventory = new ArtefactList<Artefact>();

            foreach (Artefact item in hero.ArtefactList)
            {
                if (searchArthefactsDelegate(item, predicate))
                {
                    searchInInventory.AddArtefact(item);
                }
            }

            return searchInInventory;
        }
    }
}
