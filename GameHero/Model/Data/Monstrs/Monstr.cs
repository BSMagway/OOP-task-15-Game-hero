
namespace GameHero.Model.Data.Monstrs
{
    public class Monstr
    {
        private const string DEFAULT_NAME = "Monstr";
        private const int DEFAULT_HEALT = 50;
        private const int DEFAULT_DAMAGE = 15;
        private const int DEFAULT_EVADE = 5;
        public string Name { get; private set; }
        public int Health {get; private set; }

        public int Damage { get; private set; }
        public int Evade { get; private set; }

        public Monstr() : this(DEFAULT_HEALT, DEFAULT_DAMAGE, DEFAULT_EVADE)
        {
           
        }

        public Monstr(int health, int damage, int evade)
        {
            Name = DEFAULT_NAME;
            Health = health;
            Damage = damage;
            Evade = evade;
        }

        public void SetMonstrHealthAfterDamage(int damage)
        {
            Health -= damage;
        }

        public override string ToString()
        {
            return $"{Name}";
        }




    }
}
