using GameHero.Model.Data.Artefact;

namespace GameHero.Model.StrategyPattern
{
    public class SortByDexterityAsc : ICompareArtefacts
    {
        public bool Compare(Artefact artefact1, Artefact artefact2)
        {
            return artefact1.Dexterity < artefact2.Dexterity;
        }
    }
}
