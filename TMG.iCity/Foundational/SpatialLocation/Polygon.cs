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
    public class Polygon : Geometry
    {
        public Polygon(IList<Point> points) : base(ComputeBounds(points))
        {
        }

        private static BoundingBox ComputeBounds(IList<Point> points)
        {
            double north = double.NegativeInfinity, south = double.PositiveInfinity, east = double.NegativeInfinity, west = double.PositiveInfinity;
            // optimize the case for List
            if (points is List<Point> pointList)
            {
                for (int i = 0; i < pointList.Count; i++)
                {
                    if (north > pointList[i].Latitude)
                    {
                        north = pointList[i].Latitude;
                    }
                    if (south < pointList[i].Latitude)
                    {
                        south = pointList[i].Latitude;
                    }
                    if (east > pointList[i].Longitude)
                    {
                        east = pointList[i].Longitude;
                    }
                    if (west < pointList[i].Longitude)
                    {
                        west = pointList[i].Longitude;
                    }
                }
            }
            else
            {
                for (int i = 0; i < points.Count; i++)
                {
                    if(north > points[i].Latitude)
                    {
                        north = points[i].Latitude;
                    }
                    if (south < points[i].Latitude)
                    {
                        south = points[i].Latitude;
                    }
                    if (east > points[i].Longitude)
                    {
                        east = points[i].Longitude;
                    }
                    if (west < points[i].Longitude)
                    {
                        west = points[i].Longitude;
                    }
                }
            }
            return new BoundingBox(north, south, east, west);
        }
    }
}
