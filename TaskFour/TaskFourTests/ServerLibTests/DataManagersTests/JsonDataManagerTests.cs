using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ServerLib.DataManagers;

namespace TaskFourTests.ServerLibTests.DataManagersTests
{
    [TestClass]
    public class JsonDataManagerTests
    {
        [TestMethod]
        public void ConvertArrayToString_TestOne()
        {
            var array = new double[] { 0.1, 0.2, 0.3 };
            var expected = JsonConvert.SerializeObject(array);
            var actual = JsonDataManager.ConvertArrayToString(array);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertMatrixToString_TestOne()
        {
            var array = new double[,] {
                { 0.1, 0.2, 0.3 },
                { 0.1, 0.2, 0.3 }
            };
            var expected = JsonConvert.SerializeObject(array);
            var actual = JsonDataManager.ConvertMatrixToString(array);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertStringToArray_TestOne()
        {
            var expected = new double[] { 0.1, 0.2, 0.3 };
            var actual = JsonDataManager.ConvertStringToArray(JsonConvert.SerializeObject(expected));
            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void ConvertStringToArrays_TestOne()
        {
            var expectedB = new double[] { 0.1, 0.2, 0.3 };
            var expectedA = new double[,] {
                { 0.1, 0.2, 0.3 },
                { 0.1, 0.2, 0.3 }
            };
            var testString = JsonConvert.SerializeObject(expectedA) + JsonConvert.SerializeObject(expectedB);
            var actual = JsonDataManager.ConvertStringToArrays(testString);
            Assert.AreEqual(expectedA.Length, actual.A.Length);
            for (var i = 0;i < expectedA.GetLength(0); i++)
                for (var j = 0; j < expectedA.GetLength(1); j++)
                    Assert.AreEqual(expectedA[i,j], actual.A[i,j]);
            Assert.AreEqual(expectedB.Length, actual.B.Length);
            for (var i = 0; i < expectedB.Length; i++)
                Assert.AreEqual(expectedB[i], actual.B[i]);
        }
    }
}
