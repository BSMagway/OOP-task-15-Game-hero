using GameHero.Model.Data.Artefact;

namespace GameHero.Model.StrategyPattern.Search
{
    public class SearchByDex : ISearchArtefacts<int>
    {
        public bool Predicate(Artefact artefact, int predicate)
        {
            return artefact.Dexterity == predicate;
        }
    }
}
