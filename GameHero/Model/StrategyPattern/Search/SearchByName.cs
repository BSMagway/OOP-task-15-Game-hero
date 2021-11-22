using GameHero.Model.Data.Artefact;
using System;
using System.Collections.Generic;
using System.Text;

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
