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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMG.iCity
{
    static class AssertHelper
    {
        /// <summary>
        /// Make sure that the code fails with a given exception.
        /// </summary>
        /// <typeparam name="T">The type of exception to generate</typeparam>
        /// <param name="a">The code to execute</param>
        /// <param name="message">Optional: A message to give to the test environment if it fails.</param>
        public static void FailsWith<T>(Action a, string message = null)
            where T : Exception
        {
            try
            {
                a();
            }
            catch(T)
            {
                // if we caught the exception we were looking for
                return;
            }
            catch
            {
                // fail into our other message if it was for any other type
            }
            Assert.Fail(message == null ? $"An exception of type {typeof(T).FullName} was not thrown!" : message);
        }
    }
}
