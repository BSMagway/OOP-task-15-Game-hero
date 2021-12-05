using System;
using GameHero.Model.Data;
using GameHero.Model.Data.Artefact;
using GameHero.View;

namespace GameHero.Model
{
    public static class ArtefactShopLogic
    {
        public static void SellArtefactsInShop(Dungeon dungeon, Hero hero, ArtefactsShop shop)
        {
            if (dungeon is null)
            {
                throw new ArgumentNullException($"{nameof(dungeon)} is null");
            }

            if (hero is null)
            {
                throw new ArgumentNullException($"{nameof(hero)} is null");
            }

            if (shop is null)
            {
                throw new ArgumentNullException($"{nameof(shop)} is null");
            }

            ArtefactList<Artefact> artefactsStore = ArtefactLogic.ArtefactInstore(dungeon.CurrentLevelDungeon);

            Printer.Print($"\n\"{shop.Name}\" have {artefactsStore.Size()} item for sale:\n");
            Printer.Print(ArtefactLogic.InfoAboutArtefactsList(artefactsStore));

            string key;
            Printer.Print($"\n\nEnter number for select artefacts: ");
            key = Console.ReadLine();
            int keyIndex = int.Parse(key) - 1;

            if (hero.SetMoneyOutcome(artefactsStore[keyIndex].Price))
            {
                hero.AddArtefact(artefactsStore[keyIndex]);
                Printer.Print($"\nThanks for buying");
            }
            else
            {
                Printer.Print($"Not enough money.");
            }

        }
    }
}
