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
using TMG.iCity.Foundational.Change;
using TMG.iCity.Foundational.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMG.iCity.Foundational.Monetary;
using TMG.iCity.UrbanSystem.Household;

namespace TMG.iCity.UrbanSystem.Person
{
    public sealed class Person : Manifestation<PersonPD>
    {

        public Person(Interval at, long personId, Sex sex, Instant birthDate) 
            : this(new PersonPD(personId, sex, birthDate), at)
        {

        }

        public Person(PersonPD person, Interval at) : base(person, at)
        {

        }

        public List<Qualification> Qualifications { get; } = new List<Qualification>();

        public List<Skill> Skills { get; } = new List<Skill>();

        public MonetaryValue Income { get; private set; }

        public Instant DeathDate { get; private set; }

        public List<Person> Children { get; private set; } = new List<Person>();

        public List<Person> Parents { get; } = new List<Person>();

        public Family Family { get; private set; }

    }

    public sealed class PersonPD : TimeVaryingConcept<PersonPD, Person>
    {
        public long PersonID { get; private set; }

        public Sex Sex { get; private set; }

        public Instant BirthDate { get; private set; }

        public PersonPD(long personId, Sex sex, Instant birthDate)
        {
            PersonID = personId;
            Sex = sex;
            BirthDate = birthDate;
        }
    }
}
