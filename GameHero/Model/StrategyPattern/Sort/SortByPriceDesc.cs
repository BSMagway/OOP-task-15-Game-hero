using GameHero.Model.Data.Artefact;

namespace GameHero.Model.StrategyPattern
{
    public class SortByPriceDesc : ICompareArtefacts
    {
        public bool Compare(Artefact artefact1, Artefact artefact2)
        {
            return artefact1.Price > artefact2.Price;
        }
    }
}
