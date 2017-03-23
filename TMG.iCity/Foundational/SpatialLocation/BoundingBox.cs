/*
    Copyright 2016-2017 University of Toronto

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

namespace TMG.iCity.Foundational.SpatialLocation
{
    public struct BoundingBox
    {
        public double EastBound { get; private set; }
        public double WestBound { get; private set; }
        public double NorthBound { get; private set; }
        public double SouthBound { get; private set; }

        public BoundingBox(double north, double south, double east, double west)
        {
            NorthBound = north;
            EastBound = east;
            WestBound = west;
            SouthBound = south;
        }

        public override bool Equals(object obj)
        {
            if(obj is BoundingBox other)
            {
                return other.EastBound == EastBound &&
                    other.WestBound == WestBound &&
                    other.NorthBound == NorthBound &&
                    other.SouthBound == SouthBound;
            }
            return false;
        }

        public static bool operator==(BoundingBox first, BoundingBox second)
        {
            return first.Equals(second);
        }

        public static bool operator!=(BoundingBox first, BoundingBox second)
        {
            return !first.Equals(second);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return EastBound.GetHashCode() * WestBound.GetHashCode() * NorthBound.GetHashCode() * SouthBound.GetHashCode();
            }
        }
    }
}
