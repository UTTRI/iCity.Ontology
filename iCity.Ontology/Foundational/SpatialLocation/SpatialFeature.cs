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

namespace iCity.Ontology.Foundational.SpatialLocation
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="http://geovocab.org/spatial.html"/>
    public abstract class SpatialFeature
    {
        /// <summary>
        /// 
        /// </summary>
        public Geometry Geometry { get; protected set; }

        /// <summary>
        /// Checks to see if this feature is contained within the given feature
        /// </summary>
        /// <param name="feature">The feature to check</param>
        /// <returns>True if it is contained.</returns>
        public abstract bool PartOf(SpatialFeature feature);

        /// <summary>
        /// Checks to see if this feature contains the given feature
        /// </summary>
        /// <param name="feature">The feature to check</param>
        /// <returns>True if it is contained.</returns>
        public abstract bool HasPart(SpatialFeature feature);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public abstract bool ConnectsWith(SpatialFeature feature);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public abstract bool DisconnectedFrom(SpatialFeature feature);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public abstract bool DiscreteFrom(SpatialFeature feature);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public abstract bool ExternallyConnectedWith(SpatialFeature feature);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public abstract bool Equals(SpatialFeature feature);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public abstract bool NonTangentialPropertyPartOf(SpatialFeature feature);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public abstract bool Overlaps(SpatialFeature feature);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public abstract bool PartiallyOverlaps(SpatialFeature feature);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public abstract bool IsPropertyPartOf(SpatialFeature feature);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        public abstract bool TangentialPropertyPartOf(SpatialFeature feature);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public abstract bool InconsistentWith(SpatialFeature feature);
    }
}
