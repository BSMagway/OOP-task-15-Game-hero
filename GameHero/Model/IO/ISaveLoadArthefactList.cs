using GameHero.Model.Data;
using GameHero.Model.Data.Artefact;

namespace GameHero.Model.IO
{
    public interface ISaveLoadArthefactList
    {
        void Wrtite(ArtefactList<Artefact> artefacts, string fileName);
        ArtefactList<Artefact> Read(string fileName);
    }
}
