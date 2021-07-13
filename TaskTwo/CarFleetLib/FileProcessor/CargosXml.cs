using CarFleetLib.Cargos;
using CarFleetLib.Cargos.Categories;
using CarFleetLib.Cargos.Entities;
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
    public class CargosXml : Connection, IRepository<ICargo>
    {
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
                    xmlWriter.WriteString(cargo.GetCargoCategory().ToString());
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
        public List<ICargo> Load()
        {
            var cargos = new List<ICargo>();
            // В разработочке
            /* 
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, GetCargosSchemaConnection());
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(CargosValidationEventHandler);
            using (XmlReader reader = XmlReader.Create(GetCargosConnection(), settings))
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
                                cargos.Add(creator.CreateCategory(categoryName, id));
                                break;
                        }
                    }
                }
            }
            */
            return cargos;
        }

        private void CargosValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw new SchemaValidationException(e.Message);
        }
    }
}
