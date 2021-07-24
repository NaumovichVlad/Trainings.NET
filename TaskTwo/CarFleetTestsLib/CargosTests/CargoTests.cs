using CarFleetLib.Cargos;
using CarFleetLib.Cargos.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarFleetLibTests.CargosTests
{
    [TestClass]
    public class CargoTests
    {
        [TestMethod]
        public void Equals_TestOne()
        {
            ICargo brickOne = new Brick(1, 1.05, 1.02, 0, false);
            ICargo brickTwo = new Brick(1, 1.05, 1.02, 0, false);
            var actual = brickOne.Equals(brickTwo);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_TestTwo()
        {
            ICargo brickOne = new Brick(1, 1.01, 1.02, 0, true);
            ICargo brickTwo = new Brick(1, 1.05, 1.02, 0, false);
            var actual = brickOne.Equals(brickTwo);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
    }
}
