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
using TMG.iCity.Foundational.Change;
using TMG.iCity.Foundational.SpatialLocation;
using TMG.iCity.Foundational.Time;
using TMG.iCity.Foundational.UnitsOfMeasure;

namespace TMG.iCity.Foundational.Resource
{
    public abstract class Resource<T> : Manifestation<T>
    {
        public Resource(T partOf, Interval temporalExtent, Measure capacity, Measure capacityInUse) : base(partOf, temporalExtent)
        {
            CapacityInUse = capacityInUse;
            Capacity = capacity;
        }

        public Resource(T partOf, Interval temporalExtent, Measure capacity) : base(partOf, temporalExtent)
        {
            Capacity = capacity;
            CapacityInUse = new Measure(0.0, capacity.Unit);
        }

        public Measure Capacity { get; protected set; }

        public Measure CapacityInUse { get; protected set; }

        public abstract SpatialFeature Location { get; }

        public abstract IList<ActivityOccurrence> PartisipatesIn { get; }

        public abstract IList<ActivityOccurrence> UsedIn { get; }

        public abstract IList<ActivityOccurrence> ConsumedIn { get; }

        public abstract ResourceType ResourceType { get; }
    }
}
