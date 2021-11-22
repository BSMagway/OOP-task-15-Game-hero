using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameHero.Model;
using GameHero.Model.Data;
using GameHero.Model.Data.Artefact;
using System.Collections.Generic;

namespace GameHeroTestProject
{
    [TestClass]
    public class GameHeroUnitTest
    {
        public static Hero hero;
        public static Hero heroAddArthefactsTest;

        [TestInitialize]
        public void InitializeHero()
        {

            hero = new Hero();
            heroAddArthefactsTest = new Hero();
            Artefact artefact1 = new Neck("Neck1", 3, 4, 3, 5, 10);
            Artefact artefact2 = new Neck("Neck2", 4, 3, 3, 3, 20);
            Artefact artefact3 = new Ring("Ring1", 6, 6, 6, 6, 30);
            Artefact artefact4 = new Ring("Ring2", 7, 2, 2, 2, 13);
            Artefact artefact5 = new Orb("Orb1", 1, 1, 1, 1, 1);

            hero.AddArtefact(artefact1);
            hero.AddArtefact(artefact2);
            hero.AddArtefact(artefact3);
            hero.AddArtefact(artefact4);
            hero.AddArtefact(artefact5);
        }

        [TestMethod]
        public void CountSumArtefactPriceTestMethodPositive()
        {
            int actual = HeroLogic.GetInctance().CountSumArtefactsPrice(hero);
            int expected = 74;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddArtefactTestMethodPositive()
        {
            Artefact artefact = new Orb("Orb", 5, 3, 6, 1, 1);
            heroAddArthefactsTest.AddArtefact(artefact);
            List<int> expectedList = new List<int> { 10, 8, 11, 6, 120, 40 };
            List<int> actualList = new List<int> { heroAddArthefactsTest.Strength, heroAddArthefactsTest.Intellect,
                heroAddArthefactsTest.Dexterity, heroAddArthefactsTest.Constitution, heroAddArthefactsTest.FullHealth,
                heroAddArthefactsTest.FullMana };
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void RestoreCurrentHaelthToFullHealthTestMethodPositive()
        {
            hero.SetCurrentHealthToFullHealth();
            int healthExpected = 440;
            int healthActual = hero.CurrentHealth;
            Assert.AreEqual(healthExpected, healthActual);
        }

        [TestMethod]
        public void RestoreCurrentManaToFullManaTestMethodPositive()
        {
            hero.SetCurrentManaToFullMana();
            int manaExpected = 105;
            int manaActual = hero.CurrentMana;
            Assert.AreEqual(manaExpected, manaActual);
        }

        [TestMethod]
        public void SetCurrentHealthAfterDamageTestMethodPositive()
        {
            int healthExpected = 80;
            hero.SetCurrentHealthDamageIncome(20);
            int healthActual = hero.CurrentHealth;
            Assert.AreEqual(healthExpected, healthActual);
        }

        [TestMethod]
        public void RemoveArtefactTestMethodPosititve()
        {
            hero.RemoveArtefact(0);
            HeroLogic.GetInctance().HeroFullRestoreHealthAndMana(hero);

            List<int> expectedList = new List<int> { 23, 17, 17, 17, 340 , 85, 340, 85};
            List<int> actualList = new List<int> { hero.Strength, hero.Intellect, hero.Dexterity,
                hero.Constitution, hero.FullHealth, hero.FullMana, hero.CurrentHealth, hero.CurrentMana};
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public 


    }
}
