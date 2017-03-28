/*
    Copyright 2017 University of Toronto

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
using System.Text;
using TMG.iCity.Foundational.UnitsOfMeasure;
using TMG.iCity.Foundational.UnitsOfMeasure.Time;

namespace TMG.iCity.Foundational.Time
{
    /// <summary>
    /// Describes the attributes of time
    /// </summary>
    public class DateTimeDescription
    {
        protected DateTime Time;

        public DateTimeDescription(DateTime time)
        {
            Time = time;
        }

        /// <summary>
        /// The day of the month
        /// </summary>
        public int Day => Time.Day;

        /// <summary>
        /// The day of the week
        /// </summary>
        public DayOfWeek DayOfWeek => Time.DayOfWeek;

        /// <summary>
        /// The day of the year
        /// </summary>
        public int DayOfYear => Time.DayOfYear;

        /// <summary>
        /// The hour of the day
        /// </summary>
        public int Hour => Time.Hour;

        /// <summary>
        /// The minute of the hour
        /// </summary>
        public int Minute => Time.Minute;

        /// <summary>
        /// The second of the minute
        /// </summary>
        public int Second => Time.Second;

        public static DateTimeDescription operator+(DateTimeDescription lhs, Measure rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            return lhs.Add(rhs);
        }

        public static DateTimeDescription operator +(DateTimeDescription lhs, TimeSpan rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            return lhs.Add(new Measure(rhs.TotalMinutes, MinuteUnit.Reference));
        }

        public static DateTimeDescription operator -(DateTimeDescription lhs, Measure rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            return lhs.Subtract(rhs);
        }

        public static Measure operator-(DateTimeDescription lhs, DateTimeDescription rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            if (ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }
            return new Measure((lhs.Time - rhs.Time).TotalMinutes, MinuteUnit.Reference);
        }

        public static DateTimeDescription operator -(DateTimeDescription lhs, TimeSpan rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            return lhs.Subtract(new Measure(rhs.TotalMinutes, MinuteUnit.Reference));
        }

        public static bool operator<(DateTimeDescription lhs, DateTimeDescription rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            if (ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }
            return lhs.Time < rhs.Time;
        }

        public static bool operator >(DateTimeDescription lhs, DateTimeDescription rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            if (ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }
            return lhs.Time > rhs.Time;
        }

        public static bool operator <=(DateTimeDescription lhs, DateTimeDescription rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            if (ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }
            return lhs.Time <= rhs.Time;
        }

        public static bool operator >=(DateTimeDescription lhs, DateTimeDescription rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            if (ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }
            return lhs.Time >= rhs.Time;
        }

        /// <summary>
        /// Add a time span to a DateTimeDescription to produce a new DateTimeDescription with the given offset
        /// </summary>
        /// <param name="timeSpan">The amount of time to shift by</param>
        /// <returns>A new DateTimeDescription at the given offset</returns>
        public DateTimeDescription Add(Measure timeSpan)
        {
            if(timeSpan.Unit is TimeUnit timeUnit)
            {
                return new DateTimeDescription(Time + TimeSpan.FromMinutes(timeSpan.Amount * TimeUnit.ScaleRatio(timeUnit, MinuteUnit.Reference)));
            }
            throw new InvalidOperationException("You can only add time units to a date time description!");
        }

        /// <summary>
        /// Subtract a time span to a DateTimeDescription to produce a new DateTimeDescription with the given offset
        /// </summary>
        /// <param name="timeSpan">The amount of time to shift by</param>
        /// <returns>A new DateTimeDescription at the given offset</returns>
        public DateTimeDescription Subtract(Measure timeSpan)
        {
            if (timeSpan.Unit is TimeUnit timeUnit)
            {
                return new DateTimeDescription(Time - TimeSpan.FromMinutes(timeSpan.Amount * TimeUnit.ScaleRatio(timeUnit, MinuteUnit.Reference)));
            }
            throw new InvalidOperationException("You can only subtract time units to a date time description!");
        }

        public static implicit operator DateTimeDescription(DateTime time)
        {
            return new DateTimeDescription(time);
        }

        public override bool Equals(object obj)
        {
            if(obj is DateTimeDescription other)
            {
                return Time == other.Time;
            }
            return false;
        }

        public static bool operator==(DateTimeDescription lhs, DateTimeDescription rhs)
        {
            if(ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            if(ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }
            return lhs.Time == rhs.Time;
        }

        public static bool operator !=(DateTimeDescription lhs, DateTimeDescription rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            if (ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }
            return lhs.Time != rhs.Time;
        }

        public override int GetHashCode()
        {
            return Time.GetHashCode();
        }
    }
}
