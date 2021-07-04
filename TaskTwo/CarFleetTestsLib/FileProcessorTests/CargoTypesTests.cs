using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarFleet.FileProcessor;
using CarFleet.Cargos;
using System;
using CarFleet.Cargos;

namespace CarFleetTestsLib.FileProcessorTests
{
    [TestClass]
    public class CargoTypesTests
    {
        [TestMethod]
        public void Create_TestOne()
        {
            var cargoType = new CargoType(1, "someType");
            IRepository<ICargoType> cargoTypeXml = new CargoTypesXml();
            cargoTypeXml.Create(cargoType);

        }
    }
}
