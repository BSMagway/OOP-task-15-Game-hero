using System;


namespace GameHero.Model.Data.Artefact
{
    [Serializable]
    public class Orb : Artefact
    {
        private const string TYPE_NAME = "Orb";

        public Orb()
        {
        }

        public Orb(string name, int str, int intel, int dex, int con, int price) : base(name, TYPE_NAME, str, intel, dex, con, price)
        {
        }

    }
}
