using CarFleetLib.FileProcessor;
using CarFleetLib.Trailers.Categories;
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
    public class TrailerCategoriesXmlTests : Connection
    {
        [TestMethod]
        public void Save_TestOne()
        {
            var trailerCategories = new List<ITrailerCategory>();
            trailerCategories.Add(new Awning(1));
            IRepository<ITrailerCategory> trailerCategoriesXml = new TrailerCategoriesXml();
            trailerCategoriesXml.Save(trailerCategories);
            string expected, actual;
            using (StreamReader sr = new StreamReader(GetTrailerCategoriesConnection()))
            {
                actual = sr.ReadToEnd();
            }
            using (StreamReader sr = new StreamReader("../../Data/TrailerCategoriesForTests.xml"))
            {
                expected = sr.ReadToEnd();
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
