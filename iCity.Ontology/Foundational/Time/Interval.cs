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
                return End <= interval.Start;
            }
            return false;
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
                return Start >= interval.Start && End <= interval.End;
            }
            return false;
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
                return Start == interval.Start && End == interval.End;
            }
            return false;
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
                return End == interval.End;
            }
            return false;
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
                Interval first, second;
                if(Start < interval.Start)
                {
                    first = this;
                    second = interval;
                }
                else
                {
                    first = interval;
                    second = this;
                }
                return first.End > second.Start;
            }
            return false;
        }

        public override bool Starts(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            var instant = other as Instant;
            if (instant != null)
            {
                return Start == instant.Time;
            }
            var interval = other as Interval;
            if (interval != null)
            {
                return Start == interval.Start;
            }
            return false;
        }
    }
}
