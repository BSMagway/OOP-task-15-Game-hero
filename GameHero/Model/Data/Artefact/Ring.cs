using System;
using System.Collections.Generic;
using System.Text;

namespace GameHero.Model.Data.Artefact
{
    public class Ring : Artefact
    {
        private const string TYPE_NAME = "Ring";

        public Ring()
        {
        }

        public Ring(string name, int str, int intel, int dex, int con, int price) : base(name, TYPE_NAME, str, intel, dex, con, price)
        {
        }

    }
}
