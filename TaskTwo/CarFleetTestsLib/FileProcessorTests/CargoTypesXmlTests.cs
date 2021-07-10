using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarFleet.FileProcessor;
using CarFleet.Cargos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ExceptionsLib;

namespace CarFleetTestsLib.FileProcessorTests
{
    [TestClass]
    public class CargoTypesXmlTests : Connection
    {
        [TestMethod]
        public void SchemaValidation_TestOne()
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(GetCargoTypesConnection()))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("cargoTypes");
                xmlWriter.WriteStartElement("cargoType");
                xmlWriter.WriteStartElement("typeIdddd");
                xmlWriter.WriteString("1");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("typeName");
                xmlWriter.WriteString("SomeType");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
            IRepository<ICargoType> cargoTypesXml = new CargoTypesXml();
            var exceptionFlag = false;
            try
            {
                var types = cargoTypesXml.Load();
            }
            catch (SchemaValidationException ex)
            {
                exceptionFlag = true;
                var expected = "Элемент \"cargoType\" имеет недопустимый дочерний элемент \"typeIdddd\". " +
                    "Список ожидаемых элементов: \"typeId\".";
                var actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                Assert.AreEqual(true, exceptionFlag);
            }
            
        }

        [TestMethod]

        public void Load_TestOne()
        {
            var expectedCargoTypes = new List<ICargoType>();
            expectedCargoTypes.Add(new CargoType(1, "Chemistry"));
            expectedCargoTypes.Add(new CargoType(2, "Products"));
            expectedCargoTypes.Add(new CargoType(3, "Materials"));
            IRepository<ICargoType> cargoTypesXml = new CargoTypesXml();
            cargoTypesXml.Save(expectedCargoTypes);
            var actualCargoTypes = cargoTypesXml.Load();
            
            Assert.AreEqual(expectedCargoTypes.Count, actualCargoTypes.Count);
            for (var i = 0; i < expectedCargoTypes.Count; i++)
                Assert.AreEqual(expectedCargoTypes[i], actualCargoTypes[i]);
        }
    }
}
