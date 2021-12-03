using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlaeCalculatorLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFourTests.SlaeCalculatorLibTests
{
    [TestClass]
    public class DoubleMatrixExtensionTests
    {

        [TestMethod]
        public void GetRange_TestOne()
        {
            var matrix = new double[,] { { 1, 2, 3}, { 4, 5, 6}, { 7, 8, 9 } };
            var expected = new double[,] { { 4, 5 ,6 }, { 7, 8 ,9 } };
            var actual = matrix.GetRange(1, 2);
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < actual.GetLength(0); i++)
                for (int j = 0; j < actual.GetLength(1); j++)
                    Assert.AreEqual(expected[i, j], actual[i, j]);
        }
    }
}
