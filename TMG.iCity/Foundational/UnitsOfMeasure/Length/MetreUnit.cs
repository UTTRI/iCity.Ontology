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

namespace TMG.iCity.Foundational.UnitsOfMeasure.Length
{
    public sealed class MetreUnit : LengthUnit
    {
        public static readonly MetreUnit Reference = new MetreUnit();

        protected override double ScaleToMetre => 1.0f;

        private MetreUnit()
        {
                
        }

        /// <summary>
        /// Create a measurement for the given unit
        /// </summary>
        /// <param name="ammount">The amount of the unit to create</param>
        /// <returns>A new measurement of this unit type</returns>
        public static Measure Create(double ammount)
        {
            return new Measure(ammount, Reference);
        }
    }
}
