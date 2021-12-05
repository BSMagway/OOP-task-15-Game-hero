using System;
using GameHero.Model.Data.Monstrs;

namespace GameHero.Model
{
    public static class MonstrLogic
    {
        private const int EVADE_CHANCE_RANDOM = 100;
        private const int HEALTH_MIN_RANDOM = 40;
        private const int HEALTH_MAX_RANDOM = 60;
        private const int DAMAGE_MIN_RANDOM = 10;
        private const int DAMAGE_MAX_RANDOM = 20;
        private const int EVADE_MIN_RANDOM = 2;
        private const int EVADE_MAX_RANDOM = 6;

        public static bool EvadeTrueOrFalse(int monstrEvade)
        {
            bool evadeMonster = false;

            Random randomEvade = new Random();
            if (monstrEvade >= randomEvade.Next(EVADE_CHANCE_RANDOM))
            {
                evadeMonster = true;
            }

            return evadeMonster;
        }

        public static Monstr GenerateRandomMonstr(int currentDungeonLevel)
        {
            Random randomForCration = new Random();

            int health = randomForCration.Next(HEALTH_MIN_RANDOM, HEALTH_MAX_RANDOM) * currentDungeonLevel;
            int damage = randomForCration.Next(DAMAGE_MIN_RANDOM, DAMAGE_MAX_RANDOM) * currentDungeonLevel;
            int evade = randomForCration.Next(EVADE_MIN_RANDOM, EVADE_MAX_RANDOM) * currentDungeonLevel;

            return new Monstr(health, damage, evade);
        }
    }
}
