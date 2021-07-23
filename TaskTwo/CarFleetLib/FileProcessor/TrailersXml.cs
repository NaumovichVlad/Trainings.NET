using CarFleetLib.Trailers.Categories;
using CarFleetLib.Trailers.Entities;
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
    /*
    public class TrailersXml : Connection, IRepository<ITrailer>
    {
        public void Save(List<ITrailer> trailers)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(GetTrailersConnection(), settings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("trailers");
                foreach (var trailer in trailers)
                {
                    xmlWriter.WriteStartElement("trailer");
                    xmlWriter.WriteStartElement("trailerId");
                    xmlWriter.WriteString(trailer.TrailerId.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("trailerCategoryId");
                    xmlWriter.WriteString(GetCategoryIdByName(trailer.GetTrailerCategory()).ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("weight");
                    xmlWriter.WriteString(trailer.Weight.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("volume");
                    xmlWriter.WriteString(trailer.Volume.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteString(CheckIsPerishableSetting(trailer));
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("isLiquid");
                    xmlWriter.WriteString(trailer.IsLiquid.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }

        private string CheckIsPerishableSetting(ICargo cargo)
        {
            var temperature = string.Empty;
            if (cargo.IsPerishable)
                temperature = cargo.OptimalStorageTemperature.ToString();
            return temperature;

        }
        public List<ICargo> Load()
        {
            var cargos = new List<ICargo>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, GetCargosSchemaConnection());
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(CargosValidationEventHandler);
            using (XmlReader reader = XmlReader.Create(GetCargosConnection(), settings))
            {
                var cargoId = 0;
                var categoryId = 0;
                var cargoType = string.Empty;
                double weight = 0;
                double volume = 0;
                double optimalStorageTemperature = 0;
                bool isLiquid = false;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "cargoId":
                                reader.Read();
                                cargoId = Convert.ToInt32(reader.Value);
                                break;
                            case "cargoType":
                                reader.Read();
                                cargoType = Convert.ToString(reader.Value);
                                break;
                            case "cargoCategoryId":
                                reader.Read();
                                categoryId = Convert.ToInt32(reader.Value);
                                break;
                            case "weight":
                                reader.Read();
                                weight = Convert.ToDouble(reader.Value);
                                break;
                            case "volume":
                                reader.Read();
                                volume = Convert.ToDouble(reader.Value);
                                break;
                            case "optimalStorageTemperature":
                                reader.Read();
                                optimalStorageTemperature = Convert.ToDouble(reader.Value);
                                break;
                            case "isLiquid":
                                reader.Read();
                                isLiquid = Convert.ToBoolean(reader.Value);
                                var category = GetCategoryById(categoryId);
                                var categoryCreator = new CargoCategoryCreator();
                                var cargoCreator = new ConcreteCargoCreator(cargoId, weight, volume,
                                    category.GetName().ToString(), cargoType, optimalStorageTemperature, isLiquid);
                                cargos.Add(cargoCreator.CreateCargo());
                                break;
                        }
                    }
                }
            }
            return cargos;
        }

        private ITrailerCategory GetCategoryById(int categoryId)
        {
            IRepository<ITrailerCategory> categoryReader = new TrailerCategoriesXml();
            var categories = categoryReader.Load();
            var category = categories.Find(c => c.CategoryId == categoryId);
            return category;
        }

        private int GetCategoryIdByName(TrailerCategories categoryName)
        {
            IRepository<ITrailerCategory> categoryReader = new TrailerCategoriesXml();
            var categories = categoryReader.Load();
            var category = categories.Find(c => c.GetName() == categoryName);
            return category.CategoryId;
        }

        private void CargosValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw new SchemaValidationException(e.Message);
        }
    }
    */
}
