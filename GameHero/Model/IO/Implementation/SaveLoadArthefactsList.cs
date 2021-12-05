using GameHero.Model.Data;
using GameHero.Model.Data.Artefact;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace GameHero.Model.IO.Implementation
{
    class SaveLoadArthefactsList : ISaveLoadArthefactList
    {
        public ArtefactList<Artefact> Read(string fileName)
        {
            ArtefactList<Artefact> artefacts = new ArtefactList<Artefact>();
            IFormatter stream = null;

            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    stream = new BinaryFormatter();
                    artefacts = (ArtefactList<Artefact>)stream.Deserialize(new BufferedStream(fs));
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc);
            }

            return artefacts;
        }

        public void Wrtite(ArtefactList<Artefact> artefacts, string fileName)
        {
            IFormatter stream = null;

            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    stream = new BinaryFormatter();
                    stream.Serialize(new BufferedStream(fs), artefacts);
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc);
            }
        }
    }
}
