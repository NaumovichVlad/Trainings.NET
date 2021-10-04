using EuclidCalculatorLib;
using ExceptionLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EuclidCalculatorLibTests
{
    [TestClass]
    public class EuclidCalculatorTests
    {
        [TestMethod]
        public void CalculateGcd_TestOne()
        {
            EuclidCalculator euclidCalculator= new EuclidCalculator();
            var expected = 3;
            var actual = euclidCalculator.CalculateGcd(12, 9);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotNaturalNumberException_TestOne()
        {
            NotNaturalNumberException actual = null;
            EuclidCalculator euclidCalculator = new EuclidCalculator();
            try
            {
                euclidCalculator.CalculateGcd(12, -1);
            }
            catch (NotNaturalNumberException ex)
            {
                actual = ex;
            }
            finally
            {
                Assert.IsNotNull(actual);
            }
        }

        [TestMethod]
        public void CalculateGcd_TestTwo()
        {
            EuclidCalculator euclidCalculator = new EuclidCalculator();
            var expected = 27;
            var actual = euclidCalculator.CalculateGcd(189, 81);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateGcd_TestThree()
        {
            EuclidCalculator euclidCalculator = new EuclidCalculator();
            var expected = 9;
            var actual = euclidCalculator.CalculateGcd(18, 27);
            Assert.AreEqual(expected, actual);
        }
    }
}
