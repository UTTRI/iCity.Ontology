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
using iCity.Ontology.Foundational.UnitsOfMeasure;
using iCity.Ontology.Foundational.UnitsOfMeasure.Speed;

namespace iCity.OntologyTests.Foundational.UnitsOfMeasure.Speed
{
    [TestClass]
    public class TestSpeedUnits
    {
        [TestMethod]
        public void TestMPSToKMPH()
        {
            var inMPS = new Measure(10.0, MetresPerSecondUnit.Reference);
            var inKMPH = SpeedUnit.Convert(KilometrePerHour.Reference, inMPS);
            Assert.AreEqual(36.0, inKMPH.Amount, 0.0001);
            Assert.AreEqual(KilometrePerHour.Reference, inKMPH.Unit);
        }

        [TestMethod]
        public void TestKMPHToMPS()
        {
            var inKMPH = new Measure(36.0, KilometrePerHour.Reference);
            var inMPS = SpeedUnit.Convert(MetresPerSecondUnit.Reference, inKMPH);
            Assert.AreEqual(10.0, inMPS.Amount, 0.0001);
            Assert.AreEqual(MetresPerSecondUnit.Reference, inMPS.Unit);
        }
    }
}
