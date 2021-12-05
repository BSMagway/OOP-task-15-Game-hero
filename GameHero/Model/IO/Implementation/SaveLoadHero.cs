using GameHero.Model.Data;
using System;
using System.IO;

namespace GameHero.Model.IO.Implementation
{
    class SaveLoadHero : ISaveLoadHero
    {
        private const string FILE_PATH = @"D:\itstep\oop\OOP-task-15-Game-hero\save\HeroSave\";
        private const string FILE_NAME_EXTENSION = @".save";
        private const string FILE_ARTHEFACT_EXTENSION = @"artefactList.save";


        public Hero Read(string heroName)
        {
            BinaryReader stream = null;
            Hero hero = null;
            string fileNameHero = FILE_PATH + heroName + FILE_NAME_EXTENSION;
            string fileNameArthefactsList = FILE_PATH + heroName + FILE_ARTHEFACT_EXTENSION;

            try
            {
                stream = new BinaryReader(new BufferedStream(new FileStream(fileNameHero, FileMode.Open)));

                string name = stream.ReadString();
                int strength = stream.ReadInt32();
                int intellect = stream.ReadInt32();
                int dexterity = stream.ReadInt32();
                int constitution = stream.ReadInt32();
                int money = stream.ReadInt32();
                hero = new Hero(name, strength, intellect, dexterity, constitution, money);
                hero.Level = stream.ReadInt32();
                hero.CurrentHealth = stream.ReadInt32();
                hero.CurrentMana = stream.ReadInt32();
                hero.Expirience = stream.ReadInt32();

                ISaveLoadArthefactList saveLoadArthefactList = new SaveLoadArthefactsList();
                hero.ArtefactList = saveLoadArthefactList.Read(fileNameArthefactsList);
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                stream.Close();
            }

            return hero;
        }

        public void Write(Hero hero)
        {
            BinaryWriter stream = null;
            string fileNameHero = FILE_PATH + hero.Name + ".save";
            string fileNameArthefactsList = FILE_PATH + hero.Name + "artefactList.save";

            try
            {
                stream = new BinaryWriter(new BufferedStream(new FileStream(fileNameHero, FileMode.Create)));
                stream.Write(hero.Name);
                stream.Write(hero.Strength);
                stream.Write(hero.Intellect);
                stream.Write(hero.Dexterity);
                stream.Write(hero.Constitution);
                stream.Write(hero.Money);
                stream.Write(hero.Level);
                stream.Write(hero.CurrentHealth);
                stream.Write(hero.CurrentMana);
                stream.Write(hero.Expirience);
                ISaveLoadArthefactList saveLoadArthefactList = new SaveLoadArthefactsList();
                saveLoadArthefactList.Wrtite(hero.ArtefactList, fileNameArthefactsList);
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                stream.Flush();
                stream.Close();
            }
        }
    }
}
