using CarFleetLib.Cargos.Entities;
using CarFleetLib.Cargos.Factories;
using CarFleetLib.FileProcessor;
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
    public class CargosStreamTests : Connection
    {
        public void Save_TestOne()
        {
            ICargoCreator cargoCreator = new ConcreteCargoCreator("Products", "Milk");
            var cargos = new List<ICargo>();
            cargos.Add(cargoCreator.CreateCargo(1, 100, 100, -10, true));
            IRepository<ICargo> cargosStream = new CargosStream();
            cargosStream.Save(cargos);
            string expected, actual;
            using (StreamReader sr = new StreamReader(GetCargosConnection()))
            {
                actual = sr.ReadToEnd();
            }
            using (StreamReader sr = new StreamReader("../../Data/CargosForTests.xml"))
            {
                expected = sr.ReadToEnd();
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Load_TestOne()
        {
            ICargoCreator cargoCreator = new ConcreteCargoCreator("Products", "Milk");
            var expectedList = new List<ICargo>();
            expectedList.Add(cargoCreator.CreateCargo(1, 100, 100, -10, true));
            IRepository<ICargo> cargosStream = new CargosStream();
            cargosStream.Save(expectedList);
            var actualList = cargosStream.Load();
            Assert.AreEqual(expectedList.Count, actualList.Count);
            for (var i = 0; i < actualList.Count; i++)
                Assert.AreEqual(expectedList[i], actualList[i]);
        }
    }
}
