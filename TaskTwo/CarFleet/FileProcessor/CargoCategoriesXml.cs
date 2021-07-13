using CarFleet.Cargos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using ExceptionsLib;
using CarFleet.Cargos.Categories;
using CarFleet.Cargos.Factories;

namespace CarFleet.FileProcessor
{
    public class CargoCategoriesXml : Connection, IRepository<ICargoCategory>
    {
        public void Save(List<ICargoCategory> cargoTypes)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(GetCargoCategoriesConnection(), settings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("cargoCategories");
                foreach (var cargoType in cargoTypes)
                {
                    xmlWriter.WriteStartElement("cargoCategory");
                    xmlWriter.WriteStartElement("categoryId");
                    xmlWriter.WriteString(cargoType.CategoryId.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("categoryName");
                    xmlWriter.WriteString(cargoType.GetName().ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }

        public List<ICargoCategory> Load()
        {
            var cargoCategories = new List<ICargoCategory>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, GetCargoCategoriesSchemaConnection());
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(CargoTypesValidationEventHandler);
            using (XmlReader reader = XmlReader.Create(GetCargoCategoriesConnection(), settings))
            {
                var id = 0;
                var categoryName = string.Empty;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "categoryId":
                                reader.Read();
                                id = Convert.ToInt32(reader.Value);
                                break;
                            case "categoryName":
                                reader.Read();
                                categoryName = Convert.ToString(reader.Value);
                                var creator = new CargoCategoryCreator();
                                cargoCategories.Add(creator.CreateCategory(categoryName, id));
                                break;
                        }
                    }
                }
            }
            return cargoCategories;
        }

        private void CargoTypesValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw new SchemaValidationException(e.Message);
        }
    }
}
