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

        public override bool HasBeginning
        {
            get
            {
                return false;
            }
        }

        public override bool HasDuration
        {
            get
            {
                return false;
            }
        }

        public override bool HasEnding
        {
            get
            {
                return false;
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

        public override bool After(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            var instant = other as Instant;
            if(instant != null)
            {
                return Time > instant.Time;
            }
            var interval = other as Interval;
            if(interval != null)
            {
                return Time > interval.End;
            }
            throw new InvalidOperationException($"Unable to compare a this Instant to a {other.GetType().FullName}!");
        }

        public override bool During(TemporalEntity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            // Nothing can be during an instant
            return false;
        }

        public override bool Starts(TemporalEntity other)
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

        public override bool Equals(TemporalEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
