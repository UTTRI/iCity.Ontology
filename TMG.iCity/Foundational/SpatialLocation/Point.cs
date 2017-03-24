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
using TMG.iCity.Foundational.UnitsOfMeasure;

namespace TMG.iCity.Foundational.SpatialLocation
{
    /// <summary>
    /// A Point in space given by Latitude, Longitude and Altitude
    /// </summary>
    public struct Point
    {
        public Measure Latitude { get; private set; }
        public Measure Longitude { get; private set; }
        public Measure Altitude { get; private set; }

        public Point(Measure latitude, Measure longitude)
            :this(latitude, longitude, new Measure(0.0, latitude.Unit))
        {

        }

        public Point(Measure latitude, Measure longitude, Measure altitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }

        public bool Equals(Point otherPoint)
        {
            return (Latitude == otherPoint.Latitude
                && Longitude == otherPoint.Longitude
                && Altitude == otherPoint.Altitude);
        }

        public override bool Equals(object obj)
        {
            if(obj is Point other)
            {
                return Equals(other);
            }
            return false;
        }

        public static bool operator==(Point first, Point second)
        {
            return first.Equals(second);
        }

        public static bool operator!=(Point first, Point second)
        {
            return !first.Equals(second);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Latitude.GetHashCode() + Longitude.GetHashCode() + Altitude.GetHashCode();
            }
        }
    }
}
