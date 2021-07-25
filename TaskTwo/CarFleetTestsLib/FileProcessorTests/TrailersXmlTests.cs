using CarFleetLib.Cargos.Entities;
using CarFleetLib.Cargos.Factories;
using CarFleetLib.FileProcessor;
using CarFleetLib.Trailers.Entities;
using CarFleetLib.Trailers.Factories;
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
    public class TrailersXmlTests : Connection
    {
        [TestMethod]
        public void Load_TestOne()
        {
            ITrailerCreator trailerCreator = new TrailerCreator();
            var expectedList = new List<ITrailer>();
            expectedList.Add(trailerCreator.CreateTrailer(1, 1, 1, 1, "Awning"));
            IRepository<ITrailer> trailerXml = new TrailersXml();
            trailerXml.Save(expectedList);
            var actualList = trailerXml.Load();
            Assert.AreEqual(expectedList.Count, actualList.Count);
            for (var i = 0; i < actualList.Count; i++)
                Assert.AreEqual(expectedList[i], actualList[i]);
        }

        [TestMethod]
        public void Save_TestOne()
        {
            ITrailerCreator trailerCreator = new TrailerCreator();
            var trailers = new List<ITrailer>();
            trailers.Add(trailerCreator.CreateTrailer(1, 1, 1, 1, "Awning"));
            IRepository<ITrailer> trailersXml = new TrailersXml();
            trailersXml.Save(trailers);
            string expected, actual;
            using (StreamReader sr = new StreamReader(GetTrailersConnection()))
            {
                actual = sr.ReadToEnd();
            }
            using (StreamReader sr = new StreamReader("../../Data/TrailersForTests.xml"))
            {
                expected = sr.ReadToEnd();
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
