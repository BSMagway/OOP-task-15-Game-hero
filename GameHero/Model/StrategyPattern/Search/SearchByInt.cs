using GameHero.Model.Data.Artefact;

namespace GameHero.Model.StrategyPattern.Search
{
    public class SearchByInt : ISearchArtefacts<int>
    {
        public bool Predicate(Artefact artefact, int predicate)
        {
            return artefact.Intellect == predicate;
        }
    }
}
