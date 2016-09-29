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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCity.Ontology.Foundational.Time
{
    /// <summary>
    /// An entity that ocures in time.
    /// </summary>
    public abstract class TemporalEntity
    {
        /// <summary>
        /// The entity has a beginning.
        /// </summary>
        public abstract bool HasBeginning { get; }

        /// <summary>
        /// The entity has an ending
        /// </summary>
        public abstract bool HasEnding { get; }

        /// <summary>
        /// The entity has a duration
        /// </summary>
        public abstract bool HasDuration { get; }

        /// <summary>
        /// Does this even ocure before the given entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this entity ocures before the other.</returns>
        public abstract bool Before(TemporalEntity other);

        /// <summary>
        /// Does this even ocure after the given entity.
        /// </summary>
        /// <param name="other">The entity to compare against</param>
        /// <returns>True if this entity ocures after the other.</returns>
        public abstract bool After(TemporalEntity other);

        /// <summary>
        /// If the other entity starts at the same time.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public abstract bool Starts(TemporalEntity other);

        /// <summary>
        /// If the other entity starts at the same time.
        /// </summary>
        /// <param name="other">The entity to compare against</param>
        /// <returns>True if this is the case.</returns>
        public bool StartedBy(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return other.Starts(this);
        }

        /// <summary>
        /// If the other entity ends at the same time.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public abstract bool Finishes(TemporalEntity other);

        /// <summary>
        /// If the this ends at the same time as the other entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public bool FinishedBy(TemporalEntity other)
        {
            if(other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return other.Finishes(this);
        }

        /// <summary>
        /// If there is a section of this entity that ocures at the same time as the other entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public abstract bool Overlaps(TemporalEntity other);

        /// <summary>
        /// If the this ends at the same time as the other entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public bool OverlappedBy(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return other.Overlaps(this);
        }

        /// <summary>
        /// If this entity is entirly contained inthe other entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public abstract bool During(TemporalEntity other);

        /// <summary>
        /// If this entity contains the entire other entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public bool Contains(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return other.During(this);
        }

        /// <summary>
        /// If this entity is the same as another
        /// </summary>
        /// <param name="other">The entity to check against.</param>
        /// <returns>True if this is the case.</returns>
        public abstract bool Equals(TemporalEntity other);

    }
}
