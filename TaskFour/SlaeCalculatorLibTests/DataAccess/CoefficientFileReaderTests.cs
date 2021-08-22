using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlaeCalculatorLib.DataAccess;
using System;

namespace SlaeCalculatorLibTests.DataAccess
{
    [TestClass]
    public class CoefficientFileReaderTests
    {
        [TestMethod]
        public void ReadACoefficients_TestOne()
        {
            var coefficientsAFilePath = "../../Data/CoefficientsAForTests.txt";
            var patternsFilePath = "../../Data/PatternsForTests.txt";
            ICoefficientFileReader coefficientFileReader = new CoefficientFileReader(coefficientsAFilePath, string.Empty, patternsFilePath);
            var actual = coefficientFileReader.ReadACoefficients();
            var expected = new double[2, 4] { { 1, 0, 0, 0 }, { 1, 0, 2, 0 } };
            Assert.AreEqual(expected.GetLength(0), actual.GetLength(0));
            Assert.AreEqual(expected.GetLength(1), actual.GetLength(1));
            for (int i = 0; i < expected.GetLength(0); i++)
                for (int j = 0; j < expected.GetLength(1); j++)
                    Assert.AreEqual(expected[i, j], actual[i, j]); 
        }

        [TestMethod]
        public void ReadBCoefficients_TestOne()
        {
            var coefficientsBFilePath = "../../Data/CoefficientsBForTests.txt";
            var patternsFilePath = "../../Data/PatternsForTests.txt";
            ICoefficientFileReader coefficientFileReader = new CoefficientFileReader(string.Empty, coefficientsBFilePath, patternsFilePath);
            var actual = coefficientFileReader.ReadBCoefficients();
            var expected = new double[2] { 1, 1 };
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}
