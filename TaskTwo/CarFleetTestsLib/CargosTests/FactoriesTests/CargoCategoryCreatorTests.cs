using CarFleet.Cargos.Categories;
using CarFleet.Cargos.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarFleetLibTests.CargosTests.FactoriesTests
{
    [TestClass]
    public class CargoCategoryCreatorTests
    {
        [TestMethod]
        public void CreateCategory_TestOne()
        {
            var id = 1;
            var category = "Products";
            var expected = new Products(id);
            var creator = new CargoCategoryCreator();
            var actual = creator.CreateCategory(category, id);
            Assert.AreEqual(expected, actual);
        }
    }
}
