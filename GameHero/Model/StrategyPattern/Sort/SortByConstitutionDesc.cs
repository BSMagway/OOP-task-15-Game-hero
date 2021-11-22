using GameHero.Model.Data.Artefact;

namespace GameHero.Model.StrategyPattern
{
    public class SortByConstitutionDesc : ICompareArtefacts
    {
        public bool Compare(Artefact artefact1, Artefact artefact2)
        {
            return artefact1.Constitution < artefact2.Constitution;
        }
    }
}
