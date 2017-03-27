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
using TMG.iCity.Foundational.UnitsOfMeasure.Length;
using TMG.iCity.Foundational.UnitsOfMeasure.Time;

namespace TMG.iCity.Foundational.UnitsOfMeasure.Speed
{
    /// <summary>
    /// Represents the unit of distance over time
    /// </summary>
    public abstract class SpeedUnit : UnitOfMeasure
    {
        public abstract LengthUnit DistanceUnit { get; }
        public abstract TimeUnit TimeUnit { get; }

        public static Measure Convert(SpeedUnit toType, Measure original)
        {
            if(original.Unit == toType)
            {
                return original;
            }
            if(original.Unit is SpeedUnit originalUnit)
            {
                return new Measure(original.Amount * (LengthUnit.ScaleRatio(originalUnit.DistanceUnit, toType.DistanceUnit) / TimeUnit.ScaleRatio(originalUnit.TimeUnit, toType.TimeUnit)), toType);
            }
            throw new NotSupportedException($"You can not convert a ${original.Unit.GetType().FullName} as a Speed!");
        }

        public override Measure Add(Measure lhs, Measure rhs)
        {
            return new Measure(lhs.Amount + Convert((SpeedUnit)lhs.Unit, rhs).Amount, lhs.Unit);
        }

        public override Measure Subtract(Measure lhs, Measure rhs)
        {
            return new Measure(lhs.Amount - Convert((SpeedUnit)lhs.Unit, rhs).Amount, lhs.Unit);
        }
    }
}
