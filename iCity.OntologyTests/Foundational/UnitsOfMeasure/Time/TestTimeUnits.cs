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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TMG.iCity.Foundational.UnitsOfMeasure.Time
{
    [TestClass]
    public class TestTimeUnits
    {
        [TestMethod]
        public void TestMinutesToHours()
        {
            var twoMinutes = new Measure(2.0, MinuteUnit.Reference);
            var inHours = TimeUnit.Convert(HourUnit.Reference, twoMinutes);
            Assert.AreEqual(2.0 / 60.0, inHours.Amount, 0.0001);
            Assert.AreEqual(HourUnit.Reference, inHours.Unit);
        }

        [TestMethod]
        public void TestMinutesToSeconds()
        {
            var twoMinutes = new Measure(2.0, MinuteUnit.Reference);
            var inSeconds = TimeUnit.Convert(SecondUnit.Reference, twoMinutes);
            Assert.AreEqual(2.0 * 60.0, inSeconds.Amount, 0.0001);
            Assert.AreEqual(SecondUnit.Reference, inSeconds.Unit);
        }

        [TestMethod]
        public void TestHoursToMinutes()
        {
            var twoHours = new Measure(2.0, HourUnit.Reference);
            var inMinutes = TimeUnit.Convert(MinuteUnit.Reference, twoHours);
            Assert.AreEqual(2.0 * 60.0, inMinutes.Amount, 0.0001);
            Assert.AreEqual(MinuteUnit.Reference, inMinutes.Unit);
        }

        [TestMethod]
        public void TestHoursToSeconds()
        {
            var twoHours = new Measure(2.0, HourUnit.Reference);
            var inSeconds = TimeUnit.Convert(SecondUnit.Reference, twoHours);
            Assert.AreEqual(2.0 * 60.0 * 60.0, inSeconds.Amount, 0.0001);
            Assert.AreEqual(SecondUnit.Reference, inSeconds.Unit);
        }

        [TestMethod]
        public void TestSecondsToMinutes()
        {
            var inSeconds = new Measure(120.0, SecondUnit.Reference);
            var inMinutes = TimeUnit.Convert(MinuteUnit.Reference, inSeconds);
            Assert.AreEqual(2.0, inMinutes.Amount, 0.0001);
            Assert.AreEqual(MinuteUnit.Reference, inMinutes.Unit);
        }

        [TestMethod]
        public void TestSecondsToHours()
        {
            var inSeconds = new Measure(120.0, SecondUnit.Reference);
            var inHours = TimeUnit.Convert(HourUnit.Reference, inSeconds);
            Assert.AreEqual(2.0 / 60.0, inHours.Amount, 0.0001);
            Assert.AreEqual(HourUnit.Reference, inHours.Unit);
        }
    }
}
