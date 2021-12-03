using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlaeCalculatorLib;

namespace TaskFourTests.SlaeCalculatorLibTests
{
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void LoadArrayA_TestOne()
        {
            var fileManager = new FileManager();
            var actual = fileManager.LoadArrayA(@"../../TestsData/array_a.txt");
            var expected = new[,]
            {
                {0.1, 0.1, 0.1, 0.1},
                {0.1, 0.1, 0.1, 0.1},
                {0.1, 0.1, 0.1, 0.1},
                {0.1, 0.1, 0.1, 0.1},
            };
            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.GetLength(0); i++)
                for (var j = 0; j < expected.GetLength(1); j++)
                    Assert.AreEqual(expected[i, j], actual[i, j]);
        }

        [TestMethod]
        public void LoadArrayB_TestOne()
        {
            var fileManager = new FileManager();
            var actual = fileManager.LoadArrayB(@"../../TestsData/array_b.txt");
            var expected = new[] { 0.00001, 0.00002, 0.00003, 0.00004, 0.00005};

            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.GetLength(0); i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}
