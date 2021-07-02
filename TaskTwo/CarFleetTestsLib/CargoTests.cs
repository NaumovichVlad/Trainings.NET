using CarFleetLib.Cargos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarFleetLibTests
{
    [TestClass]
    public class CargoTests
    {
        [TestMethod]
        public void Equals_TestOne()
        {
            ICargo brickOne = new Brick(1.05, 1.02);
            ICargo brickTwo = new Brick(1.05, 1.02);
            var actual = brickOne.Equals(brickTwo);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_TestTwo()
        {
            ICargo brickOne = new Brick(1.01, 1.02);
            ICargo brickTwo = new Brick(1.05, 1.02);
            var actual = brickOne.Equals(brickTwo);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
    }
}
