using CarFleetLib.Trailers.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarFleetLibTests.TrailersTests
{
    [TestClass]
    public class TrailerCaregoryTests
    {
        [TestMethod]
        public void Equals_TestOne()
        {
            var categoryId = 1;
            ITrailerCategory firstTanker = new Tanker(categoryId);
            ITrailerCategory secondTanker = new Tanker(categoryId);
            Assert.AreEqual(true, firstTanker.Equals(secondTanker));
        }

        [TestMethod]
        public void Equals_TestTwo()
        {
            var categoryId = 1;
            ITrailerCategory firstTanker = new Tanker(categoryId);
            ITrailerCategory wrongTanker = new Awning(categoryId);
            Assert.AreEqual(false, firstTanker.Equals(wrongTanker));
        }
    }
}
