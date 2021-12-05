using System;
using System.Text;


namespace GameHero.Model.Data
{
    public class Hero
    {
        private const string DEFAULT_NAME = "Hero";
        private const int DEFAULT_LEVEL = 1;
        private const int DEFAULT_START_EXPIRIENCE = 0;
        private const int DEFAULT_LEVEL_UP_EXPERIENCE = 100;
        private const int DEFAULT_START_PARAMETR_STR = 5;
        private const int DEFAULT_START_PARAMETR_INT = 5;
        private const int DEFAULT_START_PARAMETR_DEX = 5;
        private const int DEFAULT_START_PARAMETR_CON = 5;
        private const int DEFULT_START_PARAMETR_MONEY = 250;
        private const int HEALTH_MULTIPLAER_FROM_CONSTITUTION = 20;
        private const int MANA_MULTIPLAER_FROM_INTELLECT = 5;
        private const int POWER_MULTIPLAYER_FROM_STRENGTH = 2;
        private const int EVADE_DIVIDER_FROM_DEXTERITY = 10;

        private const int DEFAULT_HEALTH_AFTER_DEATH = 1;
        private const int DEFAULT_MANA_AFTER_DEATH = 1;


        public string Name { get; set; }
        public int Level { get; set; }


        private int fullHealth;
        private int fullMana;
        private int power;
        private int evade;
        private int expirience;

        public int CurrentHealth { get; set; }
        public int CurrentMana { get; set; }

        public int Strength { get; private set; }
        public int Intellect { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }
        public int Money { get; private set; }

        public ArtefactList<Artefact.Artefact> ArtefactList { get; set; }

        public int FullHealth
        {
            get
            {
                return fullHealth;
            }
            private set
            {
                fullHealth = HEALTH_MULTIPLAER_FROM_CONSTITUTION * value;
            }
        }

        public int FullMana
        {
            get
            {
                return fullMana;
            }
            private set
            {
                fullMana = MANA_MULTIPLAER_FROM_INTELLECT * value;
            }
        }

        public int Power
        {
            get
            {
                return power;
            }
            private set
            {
                power = POWER_MULTIPLAYER_FROM_STRENGTH * value;
            }
        }

        public int Evade
        {
            get
            {
                return evade;
            }
            private set
            {
                evade = value / EVADE_DIVIDER_FROM_DEXTERITY;
            }
        }

        public int Expirience
        {
            get
            {
                return expirience;
            }
            set
            {
                expirience += value;
                if (expirience >= DEFAULT_LEVEL_UP_EXPERIENCE)
                {
                    LevelUp();
                    expirience = DEFAULT_START_EXPIRIENCE;
                }
            }
        }

        private void LevelUp()
        {
            Level++;
            Strength++;
            Intellect++;
            Constitution++;
            Dexterity++;

            SetFullHealthManaPowerEvade(Constitution, Intellect, Strength, Dexterity);
        }

        public Hero() : this(DEFAULT_NAME, DEFAULT_START_PARAMETR_STR, DEFAULT_START_PARAMETR_INT, DEFAULT_START_PARAMETR_DEX, DEFAULT_START_PARAMETR_CON, DEFULT_START_PARAMETR_MONEY)
        {
        }

        public Hero(string name, int strength, int intellect, int dexterity, int constitution, int money)
        {
            Name = name;
            Level = DEFAULT_LEVEL;

            Strength = strength;
            Intellect = intellect;
            Dexterity = dexterity;
            Constitution = constitution;
            Money = money;

            SetFullHealthManaPowerEvade(Constitution, Intellect, Strength, Dexterity);

            CurrentHealth = fullHealth;
            CurrentMana = fullMana;

            ArtefactList = new ArtefactList<Artefact.Artefact>();
        }

        private void SetFullHealthManaPowerEvade(int constitution, int intellect, int strength, int dexterity)
        {
            FullHealth = constitution;
            FullMana = intellect;
            Power = strength;
            Evade = dexterity;
        }

        public void SetCurrentHealthToFullHealth()
        {
            CurrentHealth = FullHealth;
        }

        public void SetCurrentManaToFullMana()
        {
            CurrentMana = FullMana;
        }

        public void Death()
        {
            CurrentHealth = DEFAULT_HEALTH_AFTER_DEATH;
            CurrentMana = DEFAULT_MANA_AFTER_DEATH;
        }

        public void SetCurrentHealthDamageIncome(int damage)
        {
            if (CurrentHealth - damage <= 0)
            {
                Death();
            }

            CurrentHealth -= damage;
        }

        public bool SetCurrentManaSpentMana(int spentMana)
        {
            bool spent = false;
            if (CurrentMana - spentMana >= 0)
            {
                spent = true;
                CurrentMana -= spentMana;
            }

            return spent;
        }

        public void SetMoneyIncome(int money)
        {
            Money += money;
        }

        public bool SetMoneyOutcome(int money)
        {
            bool resultOperation = false;

            if (Money - money >= 0)
            {
                Money -= money;
                resultOperation = true;
            }

            return resultOperation;
        }

        public void AddArtefact(Artefact.Artefact artefact)
        {
            if (artefact is null)
            {
                throw new ArgumentNullException($"{nameof(artefact)} is null");
            }

            ArtefactList.AddArtefact(artefact);

            Strength += artefact.Strength;
            Intellect += artefact.Intellect;
            Dexterity += artefact.Dexterity;
            Constitution += artefact.Constitution;

            SetFullHealthManaPowerEvade(Constitution, Intellect, Strength, Dexterity);

        }

        public void RemoveArtefact(int index)
        {
            Strength -= ArtefactList[index].Strength;
            Intellect -= ArtefactList[index].Intellect;
            Dexterity -= ArtefactList[index].Dexterity;
            Constitution -= ArtefactList[index].Constitution;

            SetFullHealthManaPowerEvade(Constitution, Intellect, Strength, Dexterity);

            if (FullHealth < CurrentHealth)
            {
                CurrentHealth = FullHealth;
            }

            if (FullMana < CurrentMana)
            {
                CurrentMana = FullMana;
            }

            ArtefactList.RemoveArtefactByIndex(index);
        }

        public string HeroInfo()
        {
            StringBuilder heroInfo = new StringBuilder($"\n\nHero name: {Name}\t\t\t Level: {Level}\t\t\t Experience: {Expirience}");
            heroInfo.Append($"\nHealth (current/full): {CurrentHealth}/{FullHealth}\t " +
                $"Mana (current/full): {CurrentMana}/{FullMana}");
            heroInfo.Append($"\nStrength: {Strength} \t\t\t Power: {Power}");
            heroInfo.Append($"\nDexterity: {Dexterity} \t\t\t Evade: {Evade}");
            heroInfo.Append($"\nIntellect: {Intellect}");
            heroInfo.Append($"\nConstitution: {Constitution}");
            heroInfo.Append($"\nMoney: {Money}");
            heroInfo.Append($"\nHero artefacts:");
            heroInfo.Append(ArtefactLogic.InfoAboutArtefactsList(ArtefactList));

            return heroInfo.ToString();
        }

        public override string ToString()
        {
            return $"Hero name: {Name} \nlevel: {Level}\t artefacts: {ArtefactList.Size()} \nHealth: {CurrentHealth}\t Mana: {CurrentMana}";
        }
    }
}
