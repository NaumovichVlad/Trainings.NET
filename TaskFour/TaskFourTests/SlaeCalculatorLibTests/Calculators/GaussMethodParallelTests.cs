using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlaeCalculatorLib.Calculators;
using System;

namespace TaskFourTests.SlaeCalculatorLibTests.Calculators
{
    /// <summary>
    /// Сводное описание для GaussMethodParallelTests
    /// </summary>
    [TestClass]
    public class GaussMethodParallelTests
    {
        [TestMethod]
        public void Compute_TestOne()
        {
            var calculator = new GaussMethodParallel();
            var testA = new double[4, 4]
            {
                { 1, 5, 3, 2 },
                { 8, 4, 2, 5 },
                { 5, 3, 1, 9 },
                { 6, 7, 1, 6 }
            };
            var testB = new double[4] { 3, 8, 1, 2 };
            var expected = new double[4] { 335.0 / 293, -135.0 / 293.0, 517.0 / 293.0, -166.0 / 293 };
            var actual = calculator.Compute(testA, testB);
            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; i++)
                Assert.IsTrue(Math.Abs(expected[i] - actual[i]) <= Math.Pow(10, -10));
        }

        [TestMethod]

        public void CompareMethods_TestOne()
        {
            var testA = new double[4, 4]
            {
                { 1, 5, 3, 2 },
                { 8, 4, 2, 5 },
                { 5, 3, 1, 9 },
                { 6, 7, 1, 6 }
            };
            var testB = new double[4] { 3, 8, 1, 2 };
            var firstCalculator = new GaussMethodParallel();
            var secondCalculator = new GaussMethodLinear();
            var firstActual = firstCalculator.Compute(testA, testB);
            var secondActaul = secondCalculator.Compute(testA, testB);
            Assert.AreEqual(secondActaul.Length, firstActual.Length);
            for (var i = 0; i < firstActual.Length; i++)
                Assert.IsTrue(Math.Abs(firstActual[i] - secondActaul[i]) <= double.Epsilon);
        }
    }
}
