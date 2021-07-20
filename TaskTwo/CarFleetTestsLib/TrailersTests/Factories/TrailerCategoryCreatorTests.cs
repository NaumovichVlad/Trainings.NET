using CarFleetLib.Trailers.Categories;
using CarFleetLib.Trailers.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLibTests.TrailersTests.Factories
{
    [TestClass]
    public class TrailerCategoryCreatorTests
    {
        [TestMethod]
        public void CreateCategory_TestOne()
        {
            var id = 1;
            var category = "Awning";
            var expected = new Awning(id);
            ITrailerCategoryCreator creator = new TrailerCategoryCreator();
            var actual = creator.CreateCategory(category, id);
            Assert.AreEqual(expected, actual);
        }
    }
}
