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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iCity.Ontology.Foundational.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCity.OntologyTests;

namespace iCity.Ontology.Foundational.Time.Tests
{
    [TestClass()]
    public class InstantTests
    {
        [TestMethod()]
        public void InstantTest()
        {
            var now = DateTime.Now;
            var instant = new Instant(now);
            Assert.AreEqual(now, instant.Time);
        }

        [TestMethod()]
        public void BeforeTest()
        {
            var now = DateTime.Now;
            var baseTime = new Instant(now);
            var plusFiveMinutes = new Instant(now + TimeSpan.FromMinutes(5));
            Assert.IsTrue(baseTime.Before(plusFiveMinutes));
            Assert.IsFalse(baseTime.Before(baseTime));
            Assert.IsFalse(plusFiveMinutes.Before(baseTime));
            Assert.IsFalse(plusFiveMinutes.Before(plusFiveMinutes));
            AssertHelper.FailsWith<ArgumentNullException>(() => baseTime.Before(null));
        }

        [TestMethod()]
        public void AfterTest()
        {
            var now = DateTime.Now;
            var baseTime = new Instant(now);
            var plusFiveMinutes = new Instant(now + TimeSpan.FromMinutes(5));
            Assert.IsFalse(baseTime.After(plusFiveMinutes));
            Assert.IsFalse(baseTime.After(baseTime));
            Assert.IsTrue(plusFiveMinutes.After(baseTime));
            Assert.IsFalse(plusFiveMinutes.After(plusFiveMinutes));
            AssertHelper.FailsWith<ArgumentNullException>(() => baseTime.After(null));
        }

        [TestMethod()]
        public void DuringTest()
        {
            var now = DateTime.Now;
            var baseTime = new Instant(now);
            var plusFiveMinutes = new Instant(now + TimeSpan.FromMinutes(5));
            Assert.IsFalse(baseTime.During(plusFiveMinutes));
            Assert.IsFalse(baseTime.During(baseTime));
            Assert.IsFalse(plusFiveMinutes.During(baseTime));
            Assert.IsFalse(plusFiveMinutes.During(plusFiveMinutes));
            AssertHelper.FailsWith<ArgumentNullException>(() => baseTime.During(null));
        }

        [TestMethod()]
        public void StartsTest()
        {
            var now = DateTime.Now;
            var baseTime = new Instant(now);
            var plusFiveMinutes = new Instant(now + TimeSpan.FromMinutes(5));
            Assert.IsFalse(baseTime.Starts(plusFiveMinutes));
            Assert.IsFalse(baseTime.Starts(baseTime));
            Assert.IsFalse(plusFiveMinutes.Starts(baseTime));
            Assert.IsFalse(plusFiveMinutes.Starts(plusFiveMinutes));
            AssertHelper.FailsWith<ArgumentNullException>(() => baseTime.Starts(null));
        }

        [TestMethod()]
        public void FinishesTest()
        {
            var now = DateTime.Now;
            var baseTime = new Instant(now);
            var plusFiveMinutes = new Instant(now + TimeSpan.FromMinutes(5));
            Assert.IsFalse(baseTime.Finishes(plusFiveMinutes));
            Assert.IsFalse(baseTime.Finishes(baseTime));
            Assert.IsFalse(plusFiveMinutes.Finishes(baseTime));
            Assert.IsFalse(plusFiveMinutes.Finishes(plusFiveMinutes));
            AssertHelper.FailsWith<ArgumentNullException>(() => baseTime.Finishes(null));
        }

        [TestMethod()]
        public void OverlapsTest()
        {
            var now = DateTime.Now;
            var baseTime = new Instant(now);
            var plusFiveMinutes = new Instant(now + TimeSpan.FromMinutes(5));
            Assert.IsFalse(baseTime.Overlaps(plusFiveMinutes));
            Assert.IsFalse(baseTime.Overlaps(baseTime));
            Assert.IsFalse(plusFiveMinutes.Overlaps(baseTime));
            Assert.IsFalse(plusFiveMinutes.Overlaps(plusFiveMinutes));
            AssertHelper.FailsWith<ArgumentNullException>(() => baseTime.Overlaps(null));
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var now = DateTime.Now;
            var baseTime = new Instant(now);
            var plusFiveMinutes = new Instant(now + TimeSpan.FromMinutes(5));
            Assert.IsFalse(baseTime.Equals(plusFiveMinutes));
            Assert.IsTrue(baseTime.Equals(baseTime));
            Assert.IsFalse(plusFiveMinutes.Equals(baseTime));
            Assert.IsTrue(plusFiveMinutes.Equals(plusFiveMinutes));
            AssertHelper.FailsWith<ArgumentNullException>(() => baseTime.Equals(null));
        }
    }
}