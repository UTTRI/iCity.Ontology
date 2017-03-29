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
using System.Linq;
using System.Text;

namespace TMG.iCity.Foundational.Mereology
{
    /// <summary>
    /// Do not use this class.  Instead look at it for understanding of what a thing should be.
    /// </summary>
    public abstract class Thing
    {
        public Thing PartOf { get; private set; }

        public List<Thing> ProperParts { get; } = new List<Thing>();

        public List<Thing> Components { get; } = new List<Thing>();

        /// <summary>
        /// This ensures no one can create a subclass of Thing
        /// </summary>
        private Thing()
        {

        }

        public bool HasProperPart(Thing thing)
        {
            if(thing == null)
            {
                throw new ArgumentNullException(nameof(thing));
            }
            return ProperParts.Contains(thing) 
                || ProperParts.Any(part => part.HasProperPart(thing));
        }

        public bool HasComponent(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing));
            }
            return Components.Contains(thing) 
                || Components.Any(child => child.HasComponent(child));
        }

        public bool Contains(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing));
            }
            return HasProperPart(thing) || HasComponent(thing);
        }

        public bool ComponentOf(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing));
            }
            return thing.HasComponent(this);
        }

        public bool ProperPartOf(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing));
            }
            return thing.HasProperPart(this);
        }

        public bool ImmediateComponentOf(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing));
            }
            return Components.Contains(thing);
        }

        public bool ImmediateContainedIn(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing));
            }
            return Components.Contains(thing)
                || HasProperPart(thing);
        }
    }
}
