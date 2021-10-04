using EuclidCalculatorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EuclidCalculatorLibTests
{

    [TestClass]
    public class EuclidCalculatorForNumberSetTests
    {

        [TestMethod]
        public void CalculateGcdThreeNumbers_TestOne()
        {
            var calculator = new EuclidCalculatorForNumberSet(new EuclidCalculator());
            var expected = 4;
            var actual = calculator.CalculateGcd(12, 24, 8);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateGcdFourNumbers_TestOne()
        {
            var calculator = new EuclidCalculatorForNumberSet(new EuclidCalculator());
            var expected = 4;
            var actual = calculator.CalculateGcd(12, 24, 36, 8);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateGcdFiveNumbers_TestOne()
        {
            var calculator = new EuclidCalculatorForNumberSet(new EuclidCalculator());
            var expected = 4;
            var actual = calculator.CalculateGcd(12, 24, 36, 48, 8);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateGcdBinary_TestOne()
        {
            var calculator = new EuclidCalculatorForNumberSet(new EuclidCalculator());
            var expected = 4;
            var actual = calculator.CalculateGcdBinary(12, 20, out _);
            Assert.AreEqual(expected, actual);
        }
    }
}
