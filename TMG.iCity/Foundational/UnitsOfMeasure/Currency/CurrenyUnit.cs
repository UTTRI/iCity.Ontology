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

namespace TMG.iCity.Foundational.UnitsOfMeasure.Currency
{
    public abstract class CurrenyUnit : UnitOfMeasure
    {

        protected abstract double ScaleToDollar { get; }

        /// <summary>
        /// Convert one Measure of Length to another type of Length Unit
        /// </summary>
        /// <param name="toType">The type of length measurement to convert it to</param>
        /// <param name="original">The original measure</param>
        /// <returns>A new measure in the given units</returns>
        public static Measure Convert(CurrenyUnit toType, Measure original)
        {
            // if we are already in the correct unit, we are done
            if (original.Unit == toType)
            {
                return original;
            }
            // make sure that we are dealing with a measure working with lengths, and if so do the conversion
            if (original.Unit is CurrenyUnit originalLengthUnit)
            {
                return new Measure(original.Amount * (originalLengthUnit.ScaleToDollar / toType.ScaleToDollar), toType);
            }
            // otherwise this operation is not supported
            throw new NotSupportedException($"You can not convert a ${original.Unit.GetType().FullName} as a Legnth!");
        }

        public override Measure Add(Measure lhs, Measure rhs)
        {
            return new Measure(lhs.Amount + Convert((CurrenyUnit)lhs.Unit, rhs).Amount, lhs.Unit);
        }

        public override Measure Subtract(Measure lhs, Measure rhs)
        {
            return new Measure(lhs.Amount - Convert((CurrenyUnit)lhs.Unit, rhs).Amount, lhs.Unit);
        }
    }
}
