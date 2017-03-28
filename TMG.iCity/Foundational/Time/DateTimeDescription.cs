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
    }
}
