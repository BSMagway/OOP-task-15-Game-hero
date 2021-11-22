using GameHero.Model.Data.Artefact;

namespace GameHero.Model.StrategyPattern
{
    public interface ICompareArtefacts
    {
        bool Compare(Artefact artefact1, Artefact artefact2);
    }
}
