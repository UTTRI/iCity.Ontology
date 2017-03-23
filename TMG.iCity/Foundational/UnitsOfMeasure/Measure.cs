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
    public struct Measure
    {
        public double Amount { get; private set; }

        public UnitOfMeasure Unit { get; private set; }

        public Measure(double amount, UnitOfMeasure unit)
        {
            Amount = amount;
            Unit = unit;
        }

        public override bool Equals(object obj)
        {
            if(obj is Measure other)
            {
                return other.Amount == Amount &&
                    other.Unit == Unit;
            }
            return false;
        }

        public static bool operator==(Measure first, Measure second)
        {
            if (first == null || second == null) return false;
            // units can be compared like this since they are singleton
            return first.Amount == second.Amount &&
                first.Unit == second.Unit;
        }

        public static bool operator !=(Measure first, Measure second)
        {
            if (first == null || second == null) return true;
            // units can be compared like this since they are singleton
            return first.Amount != second.Amount ||
                first.Unit != second.Unit;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Amount.GetHashCode() * Unit.GetHashCode();
            }
        }
    }
}
