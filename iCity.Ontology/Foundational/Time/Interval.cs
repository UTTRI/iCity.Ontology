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
            throw new NotImplementedException();
        }

        public override bool After(TemporalEntity other)
        {
            throw new NotImplementedException();
        }

        public override bool During(TemporalEntity other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(TemporalEntity other)
        {
            throw new NotImplementedException();
        }

        public override bool Finishes(TemporalEntity other)
        {
            throw new NotImplementedException();
        }

        public override bool Overlaps(TemporalEntity other)
        {
            throw new NotImplementedException();
        }

        public override bool Starts(TemporalEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
