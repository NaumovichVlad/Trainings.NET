using CarFleetLib.Cargos;
using CarFleetLib.Cargos.Entities;
using CarFleetLib.Cargos.Factories;
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
    /// <summary>
    /// Class for reading cargo data with XmlReader/XmlWriter
    /// </summary>
    public class CargosXml : Connection, IRepository<ICargo>
    {
        /// <summary>
        /// Saving cargo data
        /// </summary>
        /// <param name="cargos"></param>
        public void Save(List<ICargo> cargos)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(GetCargosConnection(), settings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("cargos");
                foreach (var cargo in cargos)
                {
                    xmlWriter.WriteStartElement("cargo");
                    xmlWriter.WriteStartElement("cargoId");
                    xmlWriter.WriteString(cargo.CargoId.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("cargoType");
                    xmlWriter.WriteString(cargo.GetCargoType().ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("cargoCategoryId");
                    xmlWriter.WriteString(GetCategoryIdByName(cargo.GetCargoCategory().ToString()).ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("weight");
                    xmlWriter.WriteString(cargo.Weight.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("volume");
                    xmlWriter.WriteString(cargo.Volume.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("optimalStorageTemperature");
                    xmlWriter.WriteString(CheckIsPerishableSetting(cargo));
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("isLiquid");
                    xmlWriter.WriteString(cargo.IsLiquid.ToString());
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

        /// <summary>
        /// Reading cargo data from an xml file
        /// </summary>
        /// <returns></returns>
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
                                var cargoCreator = new ConcreteCargoCreator(category, cargoType);
                                cargos.Add(cargoCreator.CreateCargo(cargoId, weight, volume,
                                    optimalStorageTemperature, isLiquid));
                                break;
                        }
                    }
                }
            }
            return cargos;
        }

        private string GetCategoryById(int categoryId)
        {
            var categoryName = string.Empty;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, GetCargoCategoriesSchemaConnection());
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(CargosValidationEventHandler);
            using (XmlReader reader = XmlReader.Create(GetCargoCategoriesConnection(), settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "categoryId")
                        {
                            reader.Read();
                            if (Convert.ToInt32(reader.Value) == categoryId)
                            {
                                do
                                {
                                    reader.Read();
                                } while (reader.Name != "categoryName");
                                reader.Read();
                                categoryName = reader.Value;
                                break;
                            }
                        }
                    }
                }
            }
            return categoryName;
        }

        private int GetCategoryIdByName(string categoryName)
        {
            var categoryId = 0;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, GetCargoCategoriesSchemaConnection());
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(CargosValidationEventHandler);
            using (XmlReader reader = XmlReader.Create(GetCargoCategoriesConnection(), settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "categoryId")
                        {
                            reader.Read();
                            categoryId = Convert.ToInt32(reader.Value);
                            do
                            {
                                reader.Read();
                            } while (reader.Name != "categoryName");
                            reader.Read();
                            var categoryNameXml = reader.Value;
                            if (categoryNameXml == categoryName)
                                break;
                        }
                    }
                }
            }
            return categoryId;
        }

        private void CargosValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw new SchemaValidationException(e.Message);
        }
    }
}
