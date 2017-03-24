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
using TMG.iCity.Foundational.Time;

namespace TMG.iCity.Foundational.Activity
{
    public class DisjunctiveStateType : StateType
    {
        public override Activity PreconditionOf => throw new NotImplementedException();

        public override Activity Enables => throw new NotImplementedException();

        public override Activity EffectOf => throw new NotImplementedException();

        public override Activity CausedBy => throw new NotImplementedException();

        public override TemporalEntity AchievedAt => throw new NotImplementedException();
    }
}
