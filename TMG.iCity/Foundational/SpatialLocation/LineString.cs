/*
    Copyright 2016 University of Toronto

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
    public class LineString : Geometry
    {
        public IReadOnlyList<Point> Points { get; private set; }

        public LineString(IList<Point> points) : base(ComputeBox(points))
        {
            Points = points.ToArray();
        }

        private static BoundingBox ComputeBox(IList<Point> points)
        {
            if (points.Count == 0)
            {
                return new BoundingBox(0.0, 0.0, 0.0, 0.0, MetreUnit.Reference);
            }
            else
            {
                double north = double.NegativeInfinity, south = double.PositiveInfinity, east = double.NegativeInfinity, west = double.PositiveInfinity;
                var units = points[0].Latitude.Unit;
                for (int i = 0; i < points.Count; i++)
                {
                    var point = points[i];
                    if (north < point.Latitude.Amount)
                    {
                        north = point.Latitude.Amount;
                    }
                    if (south > point.Latitude.Amount)
                    {
                        south = point.Latitude.Amount;
                    }
                    if (east < point.Longitude.Amount)
                    {
                        east = point.Longitude.Amount;
                    }
                    if (west > point.Longitude.Amount)
                    {
                        west = point.Longitude.Amount;
                    }
                }
                return new BoundingBox(north, south, east, west, units);
            }
        }
    }
}
