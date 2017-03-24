/*
    Copyright 2016-2017 University of Toronto

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
using TMG.iCity.Foundational.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TMG.iCity.Foundational.Change
{
    public abstract class TimeVaryingConcept<T, K>
        where K : Manifestation<T>
    {
        private List<K> Manifistations { get; } = new List<K>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool ExistsAt(TemporalEntity entity)
        {
            switch (entity)
            {
                case Instant instant:
                    for (int i = 0; i < Manifistations.Count; i++)
                    {
                        if (Manifistations[i].TemporalExtent.Contains(instant))
                        {
                            return true;
                        }
                    }
                    break;
                case Interval interval:
                    for (int i = 0; i < Manifistations.Count; i++)
                    {
                        if (Manifistations[i].TemporalExtent.Contains(interval))
                        {
                            return true;
                        }
                    }
                    break;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manifestation"></param>
        /// <returns></returns>
        public bool HasManifestation(K manifestation)
        {
            if(manifestation == null)
            {
                throw new ArgumentNullException(nameof(manifestation));
            }
            return Manifistations.Contains(manifestation);
        }
    }
}
