using System;
using System.Collections.Generic;
using System.Text;
using GameHero.Model.Data.Artefact;

namespace GameHero.Model.Data
{
    public class ArtefactsShop
    {
        private const string DEFAULT_SHOP_NAME = "Artefacts shop";

        private static ArtefactsShop artefactsShop;
        public string Name { get; private set; }

        static ArtefactsShop()
        {
            artefactsShop = new ArtefactsShop();
        }

        private ArtefactsShop()
        {
            Name = DEFAULT_SHOP_NAME;
        }

        public static ArtefactsShop GetInstance()
        {
            return artefactsShop;
        }
    }
}
