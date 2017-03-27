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

namespace TMG.iCity.Foundational.UnitsOfMeasure
{
    /// <summary>
    /// Represents the concept of a unit for measurement
    /// </summary>
    public abstract class UnitOfMeasure
    {
        /// <summary>
        /// Attempt to add the two measurements
        /// </summary>
        /// <param name="lhs">The first measurement to add</param>
        /// <param name="rhs">The second measurement to add</param>
        /// <returns>A new measurement that is the combination of the two.</returns>
        public abstract Measure Add(Measure lhs, Measure rhs);

        /// <summary>
        /// Attempt to subtract the two measurements
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public abstract Measure Subtract(Measure lhs, Measure rhs);
    }
}
