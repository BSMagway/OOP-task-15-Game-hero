using GameHero.Model.Data.Artefact;

namespace GameHero.Model.StrategyPattern.Search
{
    public interface ISearchArtefacts<T>
    {
        public bool Predicate(Artefact artefact, T predicate);
    }
}
