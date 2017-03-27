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

namespace TMG.iCity.Foundational.UnitsOfMeasure.Mass
{
    public abstract class MassUnit : UnitOfMeasure
    {

        protected abstract double ScaleToGram { get; }

        public static Measure Convert(MassUnit toType, Measure original)
        {
            if (original.Unit == toType)
            {
                return original;
            }
            if (original.Unit is MassUnit originalUnit)
            {
                return new Measure(original.Amount * (originalUnit.ScaleToGram / toType.ScaleToGram), toType);
            }
            throw new NotSupportedException($"You can not convert a ${original.Unit.GetType().FullName} as a Speed!");
        }

        public override Measure Add(Measure lhs, Measure rhs)
        {
            return new Measure(lhs.Amount + Convert((MassUnit)lhs.Unit, rhs).Amount, lhs.Unit);
        }

        public override Measure Subtract(Measure lhs, Measure rhs)
        {
            return new Measure(lhs.Amount - Convert((MassUnit)lhs.Unit, rhs).Amount, lhs.Unit);
        }
    }
}
