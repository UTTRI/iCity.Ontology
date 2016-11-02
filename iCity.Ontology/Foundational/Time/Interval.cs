/*
    Copyright 2016 University of Toronto

    This file is part of iCity Ontology.

    XTMF is free software: you can redistribute it and/or modify
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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCity.Ontology.Foundational.Time
{
    public sealed class Interval : TemporalEntity
    {
        public DateTime Start { get; private set; }

        public TimeSpan Duration { get; private set; }

        public DateTime End { get { return Start + Duration; } }

        /// <summary>
        /// Create a new time interval
        /// </summary>
        /// <param name="start">The start time of the interval</param>
        /// <param name="duration">The duration of the interval. Must not be negative!</param>
        public Interval(DateTime start, TimeSpan duration)
        {
            if(duration < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(duration), "Durations must not be negative!");
            }
            Start = start;
            Duration = duration;
        }

        public override bool HasBeginning
        {
            get
            {
                return true;
            }
        }

        public override bool HasDuration
        {
            get
            {
                return true;
            }
        }

        public override bool HasEnding
        {
            get
            {
                return true;
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
                return End <= instant.Time;
            }
            var interval = other as Interval;
            if (interval != null)
            {
                return Before(interval);
            }
            return false;
        }

        /// <summary>
        /// Does this even occur before the given entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this entity occurs before the other.</returns>
        public bool Before(Interval other)
        {
            if(other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return End <= other.Start;
        }

        /// <summary>
        /// Does this even occur after the given entity.
        /// </summary>
        /// <param name="other">The entity to compare against</param>
        /// <returns>True if this entity occurs after the other.</returns>
        public bool After(Interval other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return other.Before(this);
        }

        public override bool During(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            var instant = other as Instant;
            if (instant != null)
            {
                return Duration == TimeSpan.Zero && Start == instant.Time;
            }
            var interval = other as Interval;
            if (interval != null)
            {
                return During(interval);
            }
            return false;
        }

        /// <summary>
        /// If this entity is entirely contained in the other entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public bool During(Interval other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return Start >= other.Start && End <= other.End;
        }

        public override bool Equals(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            // Shortcut in case we are the same object
            if(this == other)
            { 
                return true;
            }
            var instant = other as Instant;
            if (instant != null)
            {
                return Duration == TimeSpan.Zero && Start == instant.Time;
            }
            var interval = other as Interval;
            if (interval != null)
            {
                return Equals(interval);
            }
            return false;
        }

        /// <summary>
        /// If this entity is the same as another
        /// </summary>
        /// <param name="other">The entity to check against.</param>
        /// <returns>True if this is the case.</returns>
        public bool Equals(Interval other)
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
            return Start == other.Start && End == other.End;
        }

        public override bool Finishes(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            var instant = other as Instant;
            if (instant != null)
            {
                return End == instant.Time;
            }
            var interval = other as Interval;
            if (interval != null)
            {
                return Finishes(interval);
            }
            return false;
        }

        /// <summary>
        /// If the other entity ends at the same time.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public bool Finishes(Interval other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return End == other.End;
        }

        /// <summary>
        /// If the this ends at the same time as the other entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public bool FinishedBy(Interval other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return other.Finishes(this);
        }

        public override bool Overlaps(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            var instant = other as Instant;
            if (instant != null)
            {
                return Start <= instant.Time && instant.Time <= End;
            }
            var interval = other as Interval;
            if (interval != null)
            {
                return Overlaps(interval);
            }
            return false;
        }

        /// <summary>
        /// If there is a section of this entity that occurs at the same time as the other entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public bool Overlaps(Interval other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            Interval first, second;
            if (Start < other.Start)
            {
                first = this;
                second = other;
            }
            else
            {
                first = other;
                second = this;
            }
            return first.End > second.Start;
        }

        /// <summary>
        /// If the this ends at the same time as the other entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public bool OverlappedBy(Interval other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return other.Overlaps(this);
        }

        public override bool Starts(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            var interval = other as Interval;
            if (interval != null)
            {
                return Starts(interval);
            }
            var instant = other as Instant;
            if (instant != null)
            {
                return Starts(interval);
            }
            return false;
        }

        /// <summary>
        /// If the other entity starts at the same time.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public bool Starts(Interval other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return Start == other.Start;
        }

        /// <summary>
        /// If this entity follows or is followed directly by the other entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public bool Meets(Interval other)
        {

            return (Start == other.End || End == other.Start);
        }

        /// <summary>
        /// If this entity follows or is followed directly by the other entity.
        /// </summary>
        /// <param name="other">The entity to compare against.</param>
        /// <returns>True if this is the case.</returns>
        public bool MetBy(Interval other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return other.Meets(this);
        }

    }
}
