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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMG.iCity.Foundational.UnitsOfMeasure.Time
{
    /// <summary>
    /// Represents the concept of units dividing time
    /// </summary>
    public abstract class TimeUnit : UnitOfMeasure
    {
        protected abstract double ScaleToMinute { get; }

        /// <summary>
        /// Convert one Measure of Time to another type of Length Unit
        /// </summary>
        /// <param name="toType">The type of time measurement to convert it to</param>
        /// <param name="original">The original measure</param>
        /// <returns>A new measure in the given units</returns>
        public static Measure Convert(TimeUnit toType, Measure original)
        {
            // if we are already in the correct unit, we are done
            if (original.Unit == toType)
            {
                return original;
            }
            // make sure that we are dealing with a measure working with lengths, and if so do the conversion
            if (original.Unit is TimeUnit originalLengthUnit)
            {
                return new Measure(original.Amount * (originalLengthUnit.ScaleToMinute / toType.ScaleToMinute), toType);
            }
            // otherwise this operation is not supported
            throw new NotSupportedException($"You can not convert a ${original.Unit.GetType().FullName} as a Time!");
        }

        public static double ScaleRatio(TimeUnit numerator, TimeUnit denominator)
        {
            if(numerator == null)
            {
                throw new ArgumentNullException(nameof(numerator));
            }
            if(denominator == null)
            {
                throw new ArgumentNullException(nameof(denominator));
            }
            return numerator.ScaleToMinute / denominator.ScaleToMinute;
        }
    }
}
