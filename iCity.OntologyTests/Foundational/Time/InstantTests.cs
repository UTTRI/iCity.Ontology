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
        public void BeforeInstantTest()
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
        public void AfterInstantTest()
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
        public void EqualsInstantTest()
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

        [TestMethod()]
        public void BeforeIntervalTest()
        {
            var now = DateTime.Now;
            var baseTime = new Instant(now);
            var plusFiveMinutes = new Interval(now, TimeSpan.FromMinutes(5));
            var plusFiveMinutesAfter = new Interval(plusFiveMinutes.End, TimeSpan.FromMinutes(5));
            var plusFiveMinutesBefore = new Interval(plusFiveMinutes.Start - TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(3));
            Assert.IsFalse(baseTime.Before(plusFiveMinutes));
            Assert.IsTrue(baseTime.Before(plusFiveMinutesAfter));
            Assert.IsFalse(baseTime.Before(plusFiveMinutesBefore));
        }

        [TestMethod()]
        public void AfterIntervalTest()
        {
            var now = DateTime.Now;
            var baseTime = new Instant(now);
            var plusFiveMinutes = new Interval(now, TimeSpan.FromMinutes(5));
            var plusFiveMinutesAfter = new Interval(plusFiveMinutes.End, TimeSpan.FromMinutes(5));
            var plusFiveMinutesBefore = new Interval(plusFiveMinutes.Start - TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(3));
            Assert.IsFalse(baseTime.After(plusFiveMinutes));
            Assert.IsFalse(baseTime.After(plusFiveMinutesAfter));
            Assert.IsTrue(baseTime.After(plusFiveMinutesBefore));
        }

        [TestMethod()]
        public void EqualsIntervalTest()
        {
            var now = DateTime.Now;
            var baseTime = new Instant(now);
            var baseInterval = new Interval(now, TimeSpan.FromMinutes(0));
            var plusFiveMinutes = new Interval(now, TimeSpan.FromMinutes(5));
            var plusFiveMinutesAfter = new Interval(plusFiveMinutes.End, TimeSpan.FromMinutes(5));
            var plusFiveMinutesBefore = new Interval(plusFiveMinutes.Start - TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
            Assert.IsFalse(baseTime.Equals(plusFiveMinutes));
            Assert.IsFalse(baseTime.Equals(plusFiveMinutesAfter));
            Assert.IsFalse(baseTime.Equals(plusFiveMinutesBefore));
            Assert.IsTrue(baseTime.Equals(baseInterval));
        }

        [TestMethod()]
        public void InsideTest()
        {
            var now = DateTime.Now;
            var baseTime = new Instant(now);
            var baseTimePlusTwoMinutes = new Instant(now + TimeSpan.FromMinutes(2));
            var baseTimePlusFiveMinutes = new Instant(now + TimeSpan.FromMinutes(5));
            var plusFiveMinutes = new Interval(now, TimeSpan.FromMinutes(5));
            Assert.IsFalse(baseTime.Inside(plusFiveMinutes));
            Assert.IsFalse(baseTimePlusFiveMinutes.Inside(plusFiveMinutes));
            Assert.IsTrue(baseTimePlusTwoMinutes.Inside(plusFiveMinutes));
        }
    }
}