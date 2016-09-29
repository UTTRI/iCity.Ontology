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

namespace iCity.Ontology.Foundational.Change
{
    public abstract class Manifestation<T>
    {
        public Interval TemporalExtent { get; private set; }

        public History<T> PartOf { get; private set; }

        protected Manifestation(History<T> partOf, Interval temporalExtent)
        {
            PartOf = partOf;
            TemporalExtent = temporalExtent;
        }

        /// <summary>
        /// Create a clone of the type replicating the current state in order to continue
        /// </summary>
        /// <returns>A new manifistation</returns>
        protected abstract Manifestation<T> DeepClone();
    }
}
