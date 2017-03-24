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

namespace TMG.iCity.Foundational.UnitsOfMeasure.Length
{
    [TestClass]
    public class TestLengthUnits
    {
        [TestMethod]
        public void TestMetreToKM()
        {
            var inMetres = new Measure(10.0, MetreUnit.Reference);
            var inKM = LengthUnit.Convert(KiloMetreUnit.Reference, inMetres);
            Assert.AreEqual(inMetres.Amount, 10.0);
            Assert.AreEqual(0.01, inKM.Amount, 0.0001);
            Assert.AreEqual(KiloMetreUnit.Reference, inKM.Unit);
        }

        [TestMethod]
        public void TestKMToMetre()
        {
            var inKM = new Measure(10.0, KiloMetreUnit.Reference);
            var inMetres = LengthUnit.Convert(MetreUnit.Reference, inKM);
            Assert.AreEqual(0.01, inKM.Amount, 10.0);
            Assert.AreEqual(inMetres.Amount, 10000.0);
            Assert.AreEqual(KiloMetreUnit.Reference, inKM.Unit);
        }
    }
}
