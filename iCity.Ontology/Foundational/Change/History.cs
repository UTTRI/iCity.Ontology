/*
    Copyright 2016 University of Toronto

    This file is part of iCity Ontology.

    iCity Ontology is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    iCity Ontology is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with iCity Ontology.  If not, see <http://www.gnu.org/licenses/>.
*/
using iCity.Ontology.Foundational.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace iCity.Ontology.Foundational.Change
{
    public abstract class History<T> : ICollection<Manifestation<T>>
    {
        protected List<Manifestation<T>> Manifistations { get; private set; }

        public History()
        {
            Manifistations = new List<Manifestation<T>>();
        }

        public Interval DisjointWidth
        {
            get
            {
                var minStart = Manifistations.Min(m => m.TemporalExtent.Start);
                var maxEnd = Manifistations.Max(m => m.TemporalExtent.End);
                return new Interval(minStart, maxEnd - minStart);
            }
        }

        public int Count
        {
            get
            {
                return ((ICollection<Manifestation<T>>)Manifistations).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((ICollection<Manifestation<T>>)Manifistations).IsReadOnly;
            }
        }

        public void Add(Manifestation<T> item)
        {
            ((ICollection<Manifestation<T>>)Manifistations).Add(item);
        }

        public void Clear()
        {
            ((ICollection<Manifestation<T>>)Manifistations).Clear();
        }

        public bool Contains(Manifestation<T> item)
        {
            return ((ICollection<Manifestation<T>>)Manifistations).Contains(item);
        }

        public void CopyTo(Manifestation<T>[] array, int arrayIndex)
        {
            ((ICollection<Manifestation<T>>)Manifistations).CopyTo(array, arrayIndex);
        }

        public bool Remove(Manifestation<T> item)
        {
            return ((ICollection<Manifestation<T>>)Manifistations).Remove(item);
        }

        public IEnumerator<Manifestation<T>> GetEnumerator()
        {
            return ((ICollection<Manifestation<T>>)Manifistations).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<Manifestation<T>>)Manifistations).GetEnumerator();
        }
    }
}
