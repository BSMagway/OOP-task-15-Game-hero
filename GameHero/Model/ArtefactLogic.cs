using System;
using System.Collections.Generic;
using System.Text;
using GameHero.Model.Data.Artefact;
using GameHero.Model.Data;

namespace GameHero.Model
{
    public static class ArtefactLogic
    {
        private const int DEFAULT_GENERATE_NAME = 1000;
        private const int DEFAULT_MIN_GENERATE_ATRIBUTE = 1;
        private const int DEFAULT_MAX_GENERATE_ATRIBUTE = 3;
        private const int DEFAULT_MIN_GENERATE_PRICE = 20;
        private const int DEFAULT_MAX_GENERATE_PRICE = 60;

        public enum ArtefactType
        {
            ORB,
            NECK,
            RING
        }

        public static Artefact GenerateRandomArtefacts(int dungeonCurrentLevel)
        {
            Artefact result = null;
            Random randomGenerate = new Random();
            string name = "Random Artefacts " + randomGenerate.Next(DEFAULT_GENERATE_NAME);
            int str = randomGenerate.Next(DEFAULT_MIN_GENERATE_ATRIBUTE, DEFAULT_MAX_GENERATE_ATRIBUTE) * dungeonCurrentLevel;
            int intel = randomGenerate.Next(DEFAULT_MIN_GENERATE_ATRIBUTE, DEFAULT_MAX_GENERATE_ATRIBUTE) * dungeonCurrentLevel;
            int dex = randomGenerate.Next(DEFAULT_MIN_GENERATE_ATRIBUTE, DEFAULT_MAX_GENERATE_ATRIBUTE) * dungeonCurrentLevel;
            int con = randomGenerate.Next(DEFAULT_MIN_GENERATE_ATRIBUTE, DEFAULT_MAX_GENERATE_ATRIBUTE) * dungeonCurrentLevel;
            int price = randomGenerate.Next(DEFAULT_MIN_GENERATE_PRICE, DEFAULT_MAX_GENERATE_PRICE) * dungeonCurrentLevel;

            ArtefactType type = (ArtefactType)randomGenerate.Next((int)ArtefactType.RING + 1);

            switch (type)
            {
                case ArtefactType.ORB:
                    result = new Orb(name, str, intel, dex, con, price);
                    break;
                case ArtefactType.NECK:
                    result = new Neck(name, str, intel, dex, con, price);
                    break;
                case ArtefactType.RING:
                    result = new Ring(name, str, intel, dex, con, price);
                    break;
                default:
                    break;
            }

            return result;
        }

        public static ArtefactList<Artefact> ArtefactInstore(int dungeonCurrentLevel)
        {
            ArtefactList<Artefact> result = new ArtefactList<Artefact>();

            for (int i = 0; i < dungeonCurrentLevel; i++)
            {
                result.AddArtefact(GenerateRandomArtefacts(dungeonCurrentLevel));
            }

            return result;
        }

        public static string InfoAboutArtefactsList(ArtefactList<Artefact> artefactsList)
        {
            StringBuilder infoArtefacts = new StringBuilder();
            int index = 1;

            if (artefactsList.Size() == 0)
            {
                infoArtefacts.Append($"\nDon't have artefacts.");
            }
            else
            {
                foreach (Artefact item in artefactsList)
                {
                    infoArtefacts.Append($"\n{index} {item.ToString()}");
                    index++;
                }
            }

            return infoArtefacts.ToString();
        }
    }
}
