using CarFleetLib.Cargos.Entities;
using CarFleetLib.Trailers.Entities;
using CarFleetLib.Cargos.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLibTests.TrailersTests
{
    [TestClass]
    public class LoaderTests
    {
        [TestMethod]
        public void AwningTrailerLoader_TestOne()
        {
            var category = "Materials";
            var type = "Glass";
            var cargos = new List<ICargo>();
            var cargosForLoad = new List<ICargo>();
            var creator = new ConcreteCargoCreator(category, type);
            ILoader loader = new AwningTrailerLoader();
            for (var i = 0; i < 5; i++)
            {
                cargos.Add(creator.CreateCargo(1, 1, 1, 1, false));
                cargosForLoad.Add(creator.CreateCargo(1, 1, 1, 1, false));
            }
            var actual = loader.CheckAdditionalLoadingConditions(cargos, cargosForLoad);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AwningTrailerLoader_TestTwo()
        {
            var category = "Materials";
            var type = "Glass";
            var cargos = new List<ICargo>();
            var cargosForLoad = new List<ICargo>();
            var creator = new ConcreteCargoCreator(category, type);
            ILoader loader = new AwningTrailerLoader();
            for (var i = 0; i < 5; i++)
            {
                cargos.Add(creator.CreateCargo(1, 1, 1, 1, false));
                cargosForLoad.Add(creator.CreateCargo(1, 1, 1, 1, true));
            }
            var actual = loader.CheckAdditionalLoadingConditions(cargos, cargosForLoad);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TankerTrailerLoader_TestOne()
        {
            var category = "Chemistry";
            var type = "Gas";
            var cargos = new List<ICargo>();
            var cargosForLoad = new List<ICargo>();
            var creator = new ConcreteCargoCreator(category, type);
            ILoader loader = new TankerTrailerLoader();
            for (var i = 0; i < 5; i++)
            {
                cargos.Add(creator.CreateCargo(1, 1, 1, 1, true));
                cargosForLoad.Add(creator.CreateCargo(1, 1, 1, 1, true));
            }
            var actual = loader.CheckAdditionalLoadingConditions(cargos, cargosForLoad);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TankerTrailerLoader_TestTwo()
        {
            var category = "Chemistry";
            var type = "Gas";
            var cargos = new List<ICargo>();
            var cargosForLoad = new List<ICargo>();
            var creator = new ConcreteCargoCreator(category, type);
            ILoader loader = new TankerTrailerLoader();
            for (var i = 0; i < 5; i++)
            {
                cargos.Add(creator.CreateCargo(1, 1, 1, 1, true));
                cargosForLoad.Add(creator.CreateCargo(1, 1, 1, 1, true));
            }
            creator = new ConcreteCargoCreator(category, "Petrol");
            cargosForLoad.Add(creator.CreateCargo(1, 1, 1, 1, true));
            var actual = loader.CheckAdditionalLoadingConditions(cargos, cargosForLoad);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RefrigeratorTrailerLoader_TestOne()
        {
            var category = "Products";
            var type = "Milk";
            var cargos = new List<ICargo>();
            var cargosForLoad = new List<ICargo>();
            var creator = new ConcreteCargoCreator(category, type);
            ILoader loader = new RefrigeratorTrailerLoader();
            for (var i = 0; i < 5; i++)
            {
                cargos.Add(creator.CreateCargo(1, 1, 1, 1, false));
                cargosForLoad.Add(creator.CreateCargo(1, 1, 1, 1, false));
            }
            var actual = loader.CheckAdditionalLoadingConditions(cargos, cargosForLoad);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RefrigeratorTrailerLoader_TestTwo()
        {
            var category = "Products";
            var type = "Milk";
            var cargos = new List<ICargo>();
            var cargosForLoad = new List<ICargo>();
            var creator = new ConcreteCargoCreator(category, type);
            ILoader loader = new RefrigeratorTrailerLoader();
            for (var i = 0; i < 5; i++)
            {
                cargos.Add(creator.CreateCargo(1, 1, 1, 1, false));
                cargosForLoad.Add(creator.CreateCargo(1, 1, 1, 1, false));
            }
            cargosForLoad.Add(creator.CreateCargo(1, 1, 1, 10, false));
            var actual = loader.CheckAdditionalLoadingConditions(cargos, cargosForLoad);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
    }
}
