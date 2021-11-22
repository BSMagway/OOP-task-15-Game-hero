using System;
using System.Collections.Generic;
using System.Text;
using GameHero.Model.Data;
using GameHero.Model.Data.Monstrs;
using GameHero.View;

namespace GameHero.Model
{
    public static class BattleLogic
    {
         public static void HeroHit(Hero hero, Monstr monstr)
        {
            if (hero is null)
            {
                throw new ArgumentNullException($"{nameof(hero)} is null");
            }

            if (monstr is null)
            {
                throw new ArgumentNullException($"{nameof(monstr)} is null");
            }

            int damage = hero.Power;

            if (!MonstrLogic.EvadeTrueOrFalse(monstr.Evade))
            {
                monstr.SetMonstrHealthAfterDamage(damage);
                BattleInfo.BattleInfoHeroHit($"\nHero hit: {damage}");
            }
            else
            {
                BattleInfo.BattleInfoMonstrEvade($"\nMonstr evade");
            }
        }

        public static void MonstrHit(Hero hero, Monstr monstr)
        {
            if (hero is null)
            {
                throw new ArgumentNullException($"{nameof(hero)} is null");
            }

            if (monstr is null)
            {
                throw new ArgumentNullException($"{nameof(monstr)} is null");
            }

            int damage = monstr.Damage;

            if (!HeroLogic.GetInctance().CountEvadeTrueOrFalse(hero.Evade))
            {
                hero.SetCurrentHealthDamageIncome(damage);
                BattleInfo.BattleInfoMonstrHit($"\nMonstr hit: {damage}");
            }
            else
            {
                BattleInfo.BattleInfoHeroEvade($"\nHero evade");
            }
        }

        public static void BattleHeroWithMonstr(Hero hero, Monstr monstr, Dungeon dungeon)
        {
            if (dungeon is null)
            {
                throw new ArgumentNullException($"{nameof(dungeon)} is null");
            }

            if (hero is null)
            {
                throw new ArgumentNullException($"{nameof(hero)} is null");
            }

            if (monstr is null)
            {
                throw new ArgumentNullException($"{nameof(monstr)} is null");
            }

            while (hero.CurrentHealth > 0 && monstr.Health > 0)
            {
                HeroHit(hero, monstr);
                if (monstr.Health > 0)
                {
                    MonstrHit(hero, monstr);
                }
            }

            if (hero.CurrentHealth <= 0)
            {
                hero.Death();
            }
            else
            {
                hero.Expirience += dungeon.CurrentLevelDungeon;
                hero.AddArtefact(ArtefactLogic.GenerateRandomArtefacts(dungeon.CurrentLevelDungeon));
            }
        }
    }
}
