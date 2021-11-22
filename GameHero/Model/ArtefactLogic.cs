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
        private const int DEFAULT_GENERATE_TYPE = 3;

        private const int DEFAULT_NUMBER_TYPE_ORB = 0;
        private const int DEFAULT_NUMBER_TYPE_NECK = 1;
        private const int DEFAULT_NUMBER_TYPE_RING = 2;

        public static Artefact GenerateRandomArtefacts(int dungeonCurrentLevel)
        {
            Artefact result;
            Random randomGenerate = new Random();
            string name = "Random Artefacts " + randomGenerate.Next(DEFAULT_GENERATE_NAME);
            int str = randomGenerate.Next(DEFAULT_MIN_GENERATE_ATRIBUTE, DEFAULT_MAX_GENERATE_ATRIBUTE) * dungeonCurrentLevel;
            int intel = randomGenerate.Next(DEFAULT_MIN_GENERATE_ATRIBUTE, DEFAULT_MAX_GENERATE_ATRIBUTE) * dungeonCurrentLevel;
            int dex = randomGenerate.Next(DEFAULT_MIN_GENERATE_ATRIBUTE, DEFAULT_MAX_GENERATE_ATRIBUTE) * dungeonCurrentLevel;
            int con = randomGenerate.Next(DEFAULT_MIN_GENERATE_ATRIBUTE, DEFAULT_MAX_GENERATE_ATRIBUTE) * dungeonCurrentLevel;
            int price = randomGenerate.Next(DEFAULT_MIN_GENERATE_PRICE, DEFAULT_MAX_GENERATE_PRICE) * dungeonCurrentLevel;

            int type = randomGenerate.Next(DEFAULT_GENERATE_TYPE);

            if (type == DEFAULT_NUMBER_TYPE_ORB)
            {
                result = new Orb(name, str, intel, dex, con, price);
            }
            else if (type == DEFAULT_NUMBER_TYPE_NECK)
            {
                result = new Neck(name, str, intel, dex, con, price);

            }
            else
            {
                result = new Ring(name, str, intel, dex, con, price);
            }

            return result;
        }

        public static List<Artefact> ArtefactInstore(int dungeonCurrentLevel)
        {
            List<Artefact> result = new List<Artefact>();

            for (int i = 0; i < dungeonCurrentLevel; i++)
            {
                result.Add(GenerateRandomArtefacts(dungeonCurrentLevel));
            }

            return result;
        }

        public static string InfoAboutArtefactsList(List<Artefact> artefactsList)
        {
            StringBuilder infoArtefacts = new StringBuilder();
            int index = 1;

            if (artefactsList.Count == 0)
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
