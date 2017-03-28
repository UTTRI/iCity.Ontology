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
using TMG.iCity.Foundational.Activity;
using TMG.iCity.Foundational.SpatialLocation;
using TMG.iCity.Foundational.Time;
using TMG.iCity.Foundational.UnitsOfMeasure;

namespace TMG.iCity.Foundational.Resource
{
    public sealed class NonDivisibleResource<T> : Resource<T>
    {
        public NonDivisibleResource(T partOf, Interval temporalExtent, UnitOfMeasure unit) 
            : base(partOf, temporalExtent, new Measure(1.0, unit), new Measure(0, unit))
        {
        }

        public override SpatialFeature Location => throw new NotImplementedException();

        public override IList<ActivityOccurrence> PartisipatesIn => throw new NotImplementedException();

        public override IList<ActivityOccurrence> UsedIn => throw new NotImplementedException();

        public override IList<ActivityOccurrence> ConsumedIn => throw new NotImplementedException();

        public override ResourceType ResourceType => throw new NotImplementedException();
    }
}
