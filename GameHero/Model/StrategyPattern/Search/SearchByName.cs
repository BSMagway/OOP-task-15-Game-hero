using GameHero.Model.Data.Artefact;

namespace GameHero.Model.StrategyPattern.Search
{
    public class SearchByName : ISearchArtefacts<string>
    {
        public bool Predicate(Artefact artefact, string predicate)
        {
           
            return artefact.Name.Equals(predicate);
        }
    }
}
