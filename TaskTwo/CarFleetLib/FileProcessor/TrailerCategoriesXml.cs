using CarFleetLib.Trailers.Categories;
using CarFleetLib.Trailers.Entities;
using CarFleetLib.Trailers.Factories;
using ExceptionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace CarFleetLib.FileProcessor
{
    public class TrailerCategoriesXml : Connection, IRepository<ITrailerCategory>
    {
        public void Save(List<ITrailerCategory> trailerCategories)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(GetTrailerCategoriesConnection(), settings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("trailerCategories");
                foreach (var cargoType in trailerCategories)
                {
                    xmlWriter.WriteStartElement("trailerCategory");
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

        public List<ITrailerCategory> Load()
        {
            var trailerCategories = new List<ITrailerCategory>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, GetTrailerCategoriesSchemaConnection());
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(TrailerCategoriesValidationEventHandler);
            using (XmlReader reader = XmlReader.Create(GetTrailerCategoriesConnection(), settings))
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
                                ITrailerCategoryCreator creator = new TrailerCategoryCreator();
                                trailerCategories.Add(creator.CreateCategory(categoryName, id));
                                break;
                        }
                    }
                }
            }
            return trailerCategories;
        }

        private void TrailerCategoriesValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw new SchemaValidationException(e.Message);
        }
    }
}
