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
using TMG.iCity.UrbanSystem.Transport;

namespace TMG.iCity.UrbanSystem.Transit
{
    public class RouteLink
    {
        public StopPoint BeginsAtStop { get; private set; }

        public StopPoint EndsAtStop { get; private set; }

        public List<Arc> GoesThrough { get; private set; }

        public RouteLink(StopPoint beginsAt, StopPoint endsAt, List<Arc> goesThrough)
        {
            BeginsAtStop = beginsAt ?? throw new ArgumentNullException(nameof(beginsAt));
            EndsAtStop = endsAt ?? throw new ArgumentNullException(nameof(endsAt));
            GoesThrough = goesThrough ?? throw new ArgumentNullException(nameof(goesThrough));
        }
    }
}
