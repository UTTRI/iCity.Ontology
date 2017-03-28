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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMG.iCity.Foundational.UnitsOfMeasure.Time;

namespace TMG.iCity.Foundational.Time.Tests
{
    [TestClass()]
    public class IntervalTests
    {
        [TestMethod()]
        public void IntervalTest()
        {
            var baseTime = DateTime.Now;
            var interval = new Interval(baseTime, MinuteUnit.Create(5));
            Assert.AreEqual(baseTime, interval.Start);
            Assert.AreEqual(baseTime + TimeSpan.FromMinutes(5), interval.End);
            Assert.AreEqual(MinuteUnit.Create(5), interval.End - interval.Start);
        }

        [TestMethod()]
        public void BeforeTest()
        {
            var baseTime = DateTime.Now;
            var baseInterval = new Interval(baseTime, MinuteUnit.Create(5));
            var after5 = new Interval(baseTime + TimeSpan.FromMinutes(5), MinuteUnit.Create(5));
            Assert.IsTrue(baseInterval.Before(after5));
            Assert.IsFalse(baseInterval.Before(baseInterval));
            Assert.IsFalse(after5.Before(baseInterval));
        }

        [TestMethod()]
        public void AfterTest()
        {
            var baseTime = DateTime.Now;
            var baseInterval = new Interval(baseTime, MinuteUnit.Create(5));
            var after5 = new Interval(baseTime + TimeSpan.FromMinutes(5), MinuteUnit.Create(5));
            Assert.IsFalse(baseInterval.After(after5));
            Assert.IsFalse(baseInterval.After(baseInterval));
            Assert.IsTrue(after5.After(baseInterval));
        }

        [TestMethod()]
        public void DuringTest()
        {
            var baseTime = DateTime.Now;
            var baseInterval = new Interval(baseTime, MinuteUnit.Create(5));
            var after5 = new Interval(baseTime + TimeSpan.FromMinutes(5), MinuteUnit.Create(5));
            var after2 = new Interval(baseTime + TimeSpan.FromMinutes(2), MinuteUnit.Create(2));
            Assert.IsFalse(baseInterval.During(after5));
            Assert.IsFalse(baseInterval.During(baseInterval));
            Assert.IsFalse(baseInterval.During(after2));
            Assert.IsFalse(after5.During(baseInterval));
            Assert.IsTrue(after2.During(baseInterval));
            Assert.IsFalse(after2.During(after5));
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var baseTime = DateTime.Now;
            var baseInterval = new Interval(baseTime, MinuteUnit.Create(5));
            var baseIntervalClone = new Interval(baseTime, MinuteUnit.Create(5));
            var after5 = new Interval(baseTime + TimeSpan.FromMinutes(5), MinuteUnit.Create(5));
            Assert.IsFalse(baseInterval.Equals(after5));
            Assert.IsTrue(baseInterval.Equals(baseInterval));
            Assert.IsTrue(baseInterval.Equals(baseIntervalClone));
            Assert.IsFalse(after5.Equals(baseInterval));
        }

        [TestMethod()]
        public void FinishesTest()
        {
            var baseTime = DateTime.Now;
            var baseInterval = new Interval(baseTime, MinuteUnit.Create(5));
            var elongated = new Interval(baseTime - TimeSpan.FromMinutes(5), MinuteUnit.Create(10));
            var after5 = new Interval(baseTime + TimeSpan.FromMinutes(5), MinuteUnit.Create(5));
            var after2 = new Interval(baseTime + TimeSpan.FromMinutes(2), MinuteUnit.Create(2));
            Assert.IsFalse(baseInterval.Finishes(after5));
            Assert.IsFalse(baseInterval.Finishes(baseInterval));
            Assert.IsFalse(after5.Finishes(baseInterval));
            Assert.IsFalse(after2.Finishes(baseInterval));
            Assert.IsFalse(after2.Finishes(after5));
            Assert.IsTrue(baseInterval.Finishes(elongated));
            Assert.IsFalse(elongated.Finishes(baseInterval));
        }

        [TestMethod()]
        public void OverlapsTest()
        {
            var baseTime = DateTime.Now;
            var baseInterval = new Interval(baseTime, MinuteUnit.Create(5));
            var after5 = new Interval(baseTime + TimeSpan.FromMinutes(5), MinuteUnit.Create(5));
            var after2 = new Interval(baseTime + TimeSpan.FromMinutes(2), MinuteUnit.Create(2));
            Assert.IsFalse(baseInterval.Overlaps(after5));
            Assert.IsTrue(baseInterval.Overlaps(baseInterval));
            Assert.IsTrue(baseInterval.Overlaps(after2));
            Assert.IsFalse(after5.Overlaps(baseInterval));
            Assert.IsTrue(after2.Overlaps(baseInterval));
            Assert.IsFalse(after2.Overlaps(after5));
        }

        [TestMethod()]
        public void StartsTest()
        {
            var baseTime = DateTime.Now;
            var baseInterval = new Interval(baseTime, MinuteUnit.Create(5));
            var elongatedBaseInterval = new Interval(baseTime, MinuteUnit.Create(10));
            var after5 = new Interval(baseTime + TimeSpan.FromMinutes(5), MinuteUnit.Create(5));
            var after2 = new Interval(baseTime + TimeSpan.FromMinutes(2), MinuteUnit.Create(2));
            Assert.IsFalse(baseInterval.Starts(after5));
            Assert.IsFalse(baseInterval.Starts(baseInterval));
            Assert.IsFalse(after5.Starts(baseInterval));
            Assert.IsFalse(after2.Starts(baseInterval));
            Assert.IsFalse(after2.Starts(after5));
            Assert.IsTrue(baseInterval.Starts(elongatedBaseInterval));
            Assert.IsFalse(elongatedBaseInterval.Starts(baseInterval));
        }
    }
}