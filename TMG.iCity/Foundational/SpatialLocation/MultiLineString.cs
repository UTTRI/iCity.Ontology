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
using TMG.iCity.Foundational.UnitsOfMeasure.Length;

namespace TMG.iCity.Foundational.SpatialLocation
{
    public class MultiLineString : GeometryCollection
    {
        public IReadOnlyList<LineString> LineStringMember { get; private set; }

        public MultiLineString(IList<LineString> lineStrings) : base(ComputeBounds(lineStrings))
        {
            LineStringMember = lineStrings.ToArray();
        }

        private static BoundingBox ComputeBounds(IList<LineString> lineStrings)
        {
            double north = double.NegativeInfinity, south = double.PositiveInfinity, east = double.NegativeInfinity, west = double.PositiveInfinity;
            var unit = lineStrings.Count > 0 ?
                  lineStrings[0].BoundingBox.NorthBound.Unit
                : MetreUnit.Reference;
            for (int j = 0; j < lineStrings.Count; j++)
            {
                var innerBox = lineStrings[j].BoundingBox;
                if (north > innerBox.NorthBound.Amount)
                {
                    north = innerBox.NorthBound.Amount;
                }
                if (south < innerBox.SouthBound.Amount)
                {
                    south = innerBox.SouthBound.Amount;
                }
                if (east > innerBox.EastBound.Amount)
                {
                    east = innerBox.EastBound.Amount;
                }
                if (west < innerBox.WestBound.Amount)
                {
                    west = innerBox.WestBound.Amount;
                }
            }
            return new BoundingBox(north, south, east, west, unit);
        }
    }
}
