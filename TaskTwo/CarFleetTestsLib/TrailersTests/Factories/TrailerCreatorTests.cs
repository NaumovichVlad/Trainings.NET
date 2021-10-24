using CarFleetLib.Trailers.Entities;
using CarFleetLib.Trailers.Factories;
using ExceptionsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLibTests.TrailersTests.Factories
{
    [TestClass]
    public class TrailerCreatorTests
    {
        [TestMethod]
        
        public void CreateTrailer_TestOne()
        {
            var expected = new TankerTrailer(1, 10, 10, 10);
            var trailerCreator = new TrailerCreator();
            var actual = trailerCreator.CreateTrailer(1, 10, 10, 10, "Tanker");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateTrailer_TestTwo()
        {
            var actual = false;
            try
            {
                var trailerCreator = new TrailerCreator();
                var trailer = trailerCreator.CreateTrailer(1, 10, 10, 10, "someWrongType");
            }
            catch (ObjectExistenceException)
            {
                actual = true;
            }
            finally
            {
                var expected = true;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
