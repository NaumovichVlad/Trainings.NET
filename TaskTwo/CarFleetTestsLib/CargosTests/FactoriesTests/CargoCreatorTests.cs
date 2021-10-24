using CarFleetLib.Cargos;
using CarFleetLib.Cargos.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ExceptionsLib;
using CarFleetLib.Cargos.Entities;

namespace CarFleetLibTests.CargosTests.FactoriesTests
{
    [TestClass]
    public class CargoCreatorTests
    {
        [TestMethod]
        public void CreateCargo_TestOne()
        {
            var id = 1;
            var weight = 100;
            var volume = 100;
            var isLiquid = false;
            var temperature = 2;
            var category = "Products";
            var type = "Milk";
            var expected = new Milk(id, weight, volume, temperature, isLiquid);
            ICargoCreator creator = new ConcreteCargoCreator(category, type);
            var actual = creator.CreateCargo(id, weight, volume, temperature, isLiquid);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateCargo_TestTwo()
        {
            var id = 1;
            var weight = 100;
            var volume = 100;
            var isLiquid = false;
            var temperature = 2;
            var category = "Materials";
            var type = "Glass";
            var expected = new Glass(id, weight, volume, temperature, isLiquid);
            ICargoCreator creator = new ConcreteCargoCreator(category, type);
            var actual = creator.CreateCargo(id, weight, volume, temperature, isLiquid);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateCargo_TestThree()
        {
            var id = 1;
            var weight = 100;
            var volume = 100;
            var isLiquid = false;
            var temperature = 2;
            var category = "Chemistry";
            var type = "Gas";
            var expected = new Gas(id, weight, volume, temperature, isLiquid);
            ICargoCreator creator = new ConcreteCargoCreator(category, type);
            var actual = creator.CreateCargo(id, weight, volume, temperature, isLiquid);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateCargo_TestFour()
        {
            var flag = false;
            var id = 1;
            var weight = 100;
            var volume = 100;
            var isLiquid = false;
            var temperature = 2;
            var category = "SomeType";
            var type = "Gas";
            try
            {
                ICargoCreator creator = new ConcreteCargoCreator(category, type);
                var cargo = creator.CreateCargo(id, weight, volume, temperature, isLiquid);
            }
            catch (ObjectExistenceException)
            {
                flag = true;
            }
            finally
            {
                Assert.AreEqual(true, flag);
            }
        }
    }
}
