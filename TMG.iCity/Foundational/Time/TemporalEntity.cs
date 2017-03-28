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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMG.iCity.Foundational.Change;
using TMG.iCity.Foundational.UnitsOfMeasure;
using TMG.iCity.Foundational.UnitsOfMeasure.Time;

namespace TMG.iCity.Foundational.Time
{
    /// <summary>
    /// An entity that occurs in time.
    /// </summary>
    public abstract class TemporalEntity
    {
        /// <summary>
        /// The entity has a beginning.
        /// </summary>
        public abstract Instant HasBeginning { get; }

        /// <summary>
        /// The entity has an ending
        /// </summary>
        public abstract Instant HasEnding { get; }

        /// <summary>
        /// The entity has a duration
        /// </summary>
        public abstract Measure HasDuration { get; }

        /// <summary>
        /// Does this even occur before the given entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this entity occurs before the other.</returns>
        public abstract bool Before(TemporalEntity other);

        /// <summary>
        /// Does this even occur after the given entity.
        /// </summary>
        /// <param name="other">The entity to compare against</param>
        /// <returns>True if this entity occurs after the other.</returns>
        public bool After(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return other.Before(this);
        }

        /// <summary>
        /// If this entity is the same as another
        /// </summary>
        /// <param name="other">The entity to check against.</param>
        /// <returns>True if this is the case.</returns>
        public abstract bool Equals(TemporalEntity other);
    }
}
