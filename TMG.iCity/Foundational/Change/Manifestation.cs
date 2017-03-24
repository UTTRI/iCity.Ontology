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

namespace TMG.iCity.Foundational.Change
{
    public abstract class Manifestation<K>
    {
        public Interval TemporalExtent { get; private set; }

        public K PartOf { get; private set; }

        protected Manifestation(K partOf, Interval temporalExtent)
        {
            PartOf = partOf;
            TemporalExtent = temporalExtent;
        }

        public bool DisjointWith(TemporalEntity entity)
        {
            switch(entity)
            {
                case Instant instant:
                    return !TemporalExtent.Contains(instant);
                case Interval interval:
                    return TemporalExtent.Contains(interval);
            }
            return false;
        }

        public bool ManifestinationOf(TimeVaryingConcept<K, Manifestation<K>> entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            return entity.HasManifestation(this);
        }
    }
}
