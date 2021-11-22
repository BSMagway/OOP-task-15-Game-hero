using GameHero.Model.Data.Artefact;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameHero.Model.StrategyPattern.Search
{
    public interface ISearchArtefacts<T>
    {
        public bool Predicate(Artefact artefact, T predicate);
    }
}
