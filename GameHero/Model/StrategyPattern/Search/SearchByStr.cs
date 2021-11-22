using GameHero.Model.Data.Artefact;

namespace GameHero.Model.StrategyPattern.Search
{
    public class SearchByStr : ISearchArtefacts<int>
    {
        public bool Predicate(Artefact artefact, int predicate)
        {
            return artefact.Strength == predicate;
        }
    }
}
