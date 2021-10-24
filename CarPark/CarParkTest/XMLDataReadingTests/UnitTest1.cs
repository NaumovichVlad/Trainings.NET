using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CarPark.SemiTrailers.ReadingTrailerData;
using CarPark.SemiTrailers;
using System.Collections.Generic;

namespace CarParkTest.XMLDataReadingTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            XMLDataReading actual = new XMLDataReading();
            var fileXMLPath = @"E:\Git\Repository\Training.NET_Bolotnikova\Task_2\CarPark\CarParkTest\XMLDataReadingTests\XMLFile1.xml";
            var fileXMLSchemaPath = @"E:\Git\Repository\Training.NET_Bolotnikova\Task_2\CarPark\CarPark\SemiTrailers\ReadingTrailerData\semi_trailers.xsd";
            actual.ReadXML(fileXMLPath, fileXMLSchemaPath);
            var expected = new List<SemiTrailer>()
            {
                new Refrigerator("Refrigerator", 120, 400, 300, "r", 280, 180),
                new AutoTank("AutoTank", 220, 300, 300, "g", 120, 200),
                new TiltSemiTrailer("TiltSemiTrailer", 300, 200, 2, "f", 2, 2),              
            };
            for (var i = 0; i < actual.Amount; i++)
                Assert.AreEqual(expected[i].ToString(), actual[i].ToString());
        }
    }
}
