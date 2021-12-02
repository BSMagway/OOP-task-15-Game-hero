using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GameHero.Model.Data
{
    public class ArtefactList<T> : IEnumerable<T>
    {
        private IList<T> artefacts;

        public ArtefactList()
        {
            artefacts = new List<T>();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= artefacts.Count)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(index)} out of range");
                }

                return artefacts[index];
            }
            set
            {
                artefacts[index] = value;
            }
        }

        public int Size()
        {
            return artefacts.Count;
        }

        public void AddArtefact(T artefact)
        {
            artefacts.Add(artefact);
        }

        public void RemoveArtefactByArtefact(T artefact)
        {
            artefacts.Remove(artefact);
        }

        public void RemoveArtefactByIndex(int index)
        {
            artefacts.RemoveAt(index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return artefacts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
