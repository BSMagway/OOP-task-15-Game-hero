using GameHero.Model.Data.Artefact;

namespace GameHero.Model.StrategyPattern.Search
{
    public class SearchByCon : ISearchArtefacts<int>
    {
        public bool Predicate(Artefact artefact, int predicate)
        {
            return artefact.Constitution == predicate;
        }
    }
}
