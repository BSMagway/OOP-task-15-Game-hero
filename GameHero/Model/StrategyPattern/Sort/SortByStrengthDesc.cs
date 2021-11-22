using GameHero.Model.Data.Artefact;

namespace GameHero.Model.StrategyPattern
{
    public class SortByStrengthDesc : ICompareArtefacts
    {
        public bool Compare(Artefact artefact1, Artefact artefact2)
        {
            return artefact1.Strength > artefact2.Strength;
        }
    }
}
