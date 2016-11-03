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

namespace iCity.Ontology.Foundational.Location
{
    public sealed class Point : Location
    {
        public override bool HasPart(SpatialFeature feature)
        {
            if (feature == null)
            {
                throw new ArgumentNullException(nameof(feature));
            }
            return false;
        }

        public override bool PartOf(SpatialFeature feature)
        {
            if(feature == null)
            {
                throw new ArgumentNullException(nameof(feature));
            }
            return feature.HasPart(this);
        }

        public override bool ConnectsWith(SpatialFeature feature)
        {
            if (feature == null)
            {
                throw new ArgumentNullException(nameof(feature));
            }
            return false;
        }

        public override bool DisconnectedFrom(SpatialFeature feature)
        {
            throw new NotImplementedException();
        }

        public override bool DiscreteFrom(SpatialFeature feature)
        {
            throw new NotImplementedException();
        }

        public override bool ExternallyConnectedWith(SpatialFeature feature)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(SpatialFeature feature)
        {
            throw new NotImplementedException();
        }

        public override bool NonTangentialPropertyPartOf(SpatialFeature feature)
        {
            throw new NotImplementedException();
        }

        public override bool Overlaps(SpatialFeature feature)
        {
            throw new NotImplementedException();
        }

        public override bool PartiallyOverlaps(SpatialFeature feature)
        {
            throw new NotImplementedException();
        }

        public override bool IsPropertyPartOf(SpatialFeature feature)
        {
            throw new NotImplementedException();
        }

        public override bool TangentialPropertyPartOf(SpatialFeature feature)
        {
            throw new NotImplementedException();
        }

        public override bool InconsistentWith(SpatialFeature feature)
        {
            throw new NotImplementedException();
        }

        public Point(float latitude, float longitude, float altitude) : base(latitude, longitude, altitude)
        {
            
        }
    }
}
