using CarFleetLib.FileProcessor;
using CarFleetLib.Trucks.Entities;
using CarFleetLib.Trucks.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLibTests.FileProcessorTests
{
    [TestClass]
    public class TrucksStreamTests : Connection
    {
        [TestMethod]
        public void Load_TestOne()
        {
            ITruckCreator truckCreator = new TruckCreator();
            var expectedList = new List<ITruck>();
            expectedList.Add(truckCreator.CreateTruck(1, "MAZ", "1111", 1, 1, 1));
            IRepository<ITruck> trucksXml = new TrucksStream();
            trucksXml.Save(expectedList);
            var actualList = trucksXml.Load();
            Assert.AreEqual(expectedList.Count, actualList.Count);
            for (var i = 0; i < actualList.Count; i++)
                Assert.AreEqual(expectedList[i], actualList[i]);
        }
    }
}
