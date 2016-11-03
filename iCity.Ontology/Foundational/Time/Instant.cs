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
    /// A single point in time.
    /// </summary>
    public sealed class Instant : TemporalEntity
    {
        public DateTime Time { get; private set; }

        public Instant(DateTime time)
        {
            Time = time;
        }

        public override Instant HasBeginning
        {
            get
            {
                return this;
            }
        }

        public override TimeSpan HasDuration
        {
            get
            {
                return TimeSpan.Zero;
            }
        }

        public override Instant HasEnding
        {
            get
            {
                return this;
            }
        }

        public override bool Before(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            var instant = other as Instant;
            if (instant != null)
            {
                return Time < instant.Time;
            }
            var interval = other as Interval;
            if (interval != null)
            {
                return Time < interval.Start;
            }
            throw new InvalidOperationException($"Unable to compare a this Instant to a {other.GetType().FullName}!");
        }

        public override bool Equals(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            // Shortcut in case we are the same object
            if (this == other)
            {
                return true;
            }
            // Nothing can be during an instant
            var instant = other as Instant;
            if(instant != null)
            {
                return Time == instant.Time;
            }
            var interval = other as Interval;
            if (interval != null)
            {
                return Time == interval.Start && interval.HasDuration == TimeSpan.Zero;
            }
            return false;
        }

        /// <summary>
        /// If this entity is inside of the interval.  Does not count
        /// if it is at the start or end of the interval.
        /// </summary>
        /// <param name="interval">The entity to check against.</param>
        /// <returns>True if this is the case.</returns>
        public bool Inside(Interval interval)
        {
            if(interval == null)
            {
                throw new ArgumentNullException(nameof(Interval));
            }
            return interval.Start < Time && Time < interval.End;
        }

        /// <summary>
        /// Creates a new instant with the given delta
        /// </summary>
        /// <param name="us">The Instant in question.</param>
        /// <param name="delta">The delta to apply to the instant.</param>
        /// <returns>A new instant with the given shift</returns>
        public static Instant operator+(Instant us, TimeSpan delta)
        {
            return new Instant(us.Time + delta);
        }

        /// <summary>
        /// Creates a new instant with the opposite of the given delta
        /// </summary>
        /// <param name="us">The Instant in question.</param>
        /// <param name="delta">The delta to apply to the instant.</param>
        /// <returns>A new instant with the opposite of the given shift</returns>
        public static Instant operator -(Instant us, TimeSpan delta)
        {
            return new Instant(us.Time - delta);
        }
    }
}
