using System;


namespace GameHero.Model.Data.Artefact
{
    [Serializable]
    public class Neck : Artefact
    {
        private const string TYPE_NAME = "Neck";

        public Neck()
        {
        }

        public Neck(string name, int str, int intel, int dex, int con, int price) : base(name, TYPE_NAME, str, intel, dex, con, price)
        {
        }

    }
}
