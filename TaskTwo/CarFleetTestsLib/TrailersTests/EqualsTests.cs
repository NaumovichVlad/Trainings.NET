using CarFleetLib.Trailers.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLibTests.TrailersTests
{
    [TestClass]
    public class EqualsTests
    {
        [TestMethod]
        public void Equals_TestOne()
        {
            var creator = new TrailerCreator();
            var firstTrailer = creator.CreateTrailer(1, 1, 1, 1, "Awning");
            var secondTrailer = creator.CreateTrailer(1, 1, 1, 1, "Awning");
            var actual = firstTrailer.Equals(secondTrailer);
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Equals_TestTwo()
        {
            var creator = new TrailerCreator();
            var firstTrailer = creator.CreateTrailer(1, 1, 1, 1, "Awning");
            var secondTrailer = creator.CreateTrailer(1, 1, 1, 1, "Tanker");
            var actual = firstTrailer.Equals(secondTrailer);
            Assert.AreEqual(false, actual);
        }
    }
}
