using CarFleetLib.Trucks.Entities;
using CarFleetLib.Trucks.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLibTests.TrucksTests.Factories
{
    [TestClass]
    public class TruckCreatorTests
    {
        [TestMethod]

        public void CreateTruck_TestOne()
        {
            var expected = new TruckTractor(1, "MAZ", "11111A", 1, 1, 1);
            var creator = new TruckCreator();
            var actual = creator.CreateTruck(1, "MAZ", "11111A", 1, 1, 1);
            Assert.AreEqual(expected, actual);
        }
    }
}
