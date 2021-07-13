using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarFleetLib.FileProcessor;
using CarFleetLib.Cargos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ExceptionsLib;
using CarFleetLib.Cargos.Categories;

namespace CarFleetLibTests.FileProcessorTests
{
    [TestClass]
    public class CargoTypesXmlTests : Connection
    {
        [TestMethod]
        public void Save_TestOne()
        {
            var cargoTypes = new List<ICargoCategory>();
            cargoTypes.Add(new Chemistry(1));
            IRepository<ICargoCategory> cargoTypesXml = new CargoCategoriesXml();
            cargoTypesXml.Save(cargoTypes);
            string expected, actual;
            using (StreamReader sr = new StreamReader(GetCargoCategoriesConnection()))
            {
                actual = sr.ReadToEnd();
            }
            using (StreamReader sr = new StreamReader("../../Data/CargoCategoriesForTests.xml"))
            {
                expected = sr.ReadToEnd();
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void Load_TestOne()
        {
            var expectedCargoTypes = new List<ICargoCategory>();
            expectedCargoTypes.Add(new Chemistry(1));
            expectedCargoTypes.Add(new Products(2));
            expectedCargoTypes.Add(new Materials(3));
            IRepository<ICargoCategory> cargoTypesXml = new CargoCategoriesXml();
            cargoTypesXml.Save(expectedCargoTypes);
            var actualCargoTypes = cargoTypesXml.Load();
            
            Assert.AreEqual(expectedCargoTypes.Count, actualCargoTypes.Count);
            for (var i = 0; i < expectedCargoTypes.Count; i++)
                Assert.AreEqual(expectedCargoTypes[i], actualCargoTypes[i]);
        }

        [TestMethod]
        public void SchemaValidation_TestOne()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(GetCargoCategoriesConnection(), settings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("cargoCategories");
                xmlWriter.WriteStartElement("cargoCategory");
                xmlWriter.WriteStartElement("typeIdddd");
                xmlWriter.WriteString("1");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("categoryName");
                xmlWriter.WriteString("SomeType");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
            IRepository<ICargoCategory> cargoTypesXml = new CargoCategoriesXml();
            var exceptionFlag = false;
            try
            {
                var types = cargoTypesXml.Load();
            }
            catch (SchemaValidationException ex)
            {
                exceptionFlag = true;
                var expected = "Элемент \"cargoCategory\" имеет недопустимый дочерний элемент \"typeIdddd\". " +
                    "Список ожидаемых элементов: \"categoryId\".";
                var actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                Assert.AreEqual(true, exceptionFlag);
            } 
        }
    }
}
