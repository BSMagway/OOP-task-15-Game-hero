using System;
using System.Collections.Generic;
using System.Text;

namespace GameHero.Model.Data
{
    public class Dungeon
    {
        private const int DEFAULT_MAX_LEVEL = 5;
        private const int DEFAULT_Current_LEVEL = 1;
        private const string DEFULT_NAME = "Dungeon";
        private int currentLevelDungeon;
        
        public string Name { get; private set; }
        public int MaxLevelDungeon { get; private set; }
        public int CurrentLevelDungeon
        {
            get
            {
                return currentLevelDungeon;
            }
            set
            {
                if (value > DEFAULT_Current_LEVEL || value <= DEFAULT_MAX_LEVEL)
                {
                    currentLevelDungeon = value;
                }
            }
        }

        public Dungeon()
        {
            Name = DEFULT_NAME;
            MaxLevelDungeon = DEFAULT_MAX_LEVEL;
            CurrentLevelDungeon = DEFAULT_Current_LEVEL;
        }
    }
}
