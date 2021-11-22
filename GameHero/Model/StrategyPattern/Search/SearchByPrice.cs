using GameHero.Model.Data.Artefact;

namespace GameHero.Model.StrategyPattern.Search
{
    public class SearchByPrice : ISearchArtefacts<int>
    {
        public bool Predicate(Artefact artefact, int predicate)
        {
            return artefact.Price == predicate;
        }
    }
}
