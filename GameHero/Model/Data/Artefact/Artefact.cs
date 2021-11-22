using System;
using System.Collections.Generic;
using System.Text;

namespace GameHero.Model.Data.Artefact
{
    public class Artefact
    {
        public string Name { get; private set; }

        public string Type { get; private set; }

        public int Strength { get; private set; }
        public int Intellect { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }

        public int Price { get; private set; }

        public Artefact()
        { }

        public Artefact(string name, string type, int strength, int intellect, int dexterity, int constitution, int price)
        {
            Name = name;
            Type = type;
            Strength = strength;
            Intellect = intellect;
            Dexterity = dexterity;
            Constitution = constitution;
            Price = price;
        }

        public override string ToString()
        {
            return $"Name: {Name}\t type: {Type}\t strength: {Strength} intellect: {Intellect} " +
                $"dexterity: {Dexterity} constitution: {Constitution} price: {Price}";
        }
    }
}
