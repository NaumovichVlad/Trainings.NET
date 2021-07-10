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

namespace CarFleet.FileProcessor
{
    public class CargoTypesXml : Connection, IRepository<ICargoType>
    {
        public void Save(List<ICargoType> cargoTypes)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(GetCargoTypesConnection(), settings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("cargoTypes");
                foreach (var cargoType in cargoTypes)
                {
                    xmlWriter.WriteStartElement("cargoType");
                    xmlWriter.WriteStartElement("typeId");
                    xmlWriter.WriteString(cargoType.TypeId.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("typeName");
                    xmlWriter.WriteString(cargoType.TypeName);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }

        public List<ICargoType> Load()
        {
            var cargoTypes = new List<ICargoType>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, GetCargoTypesSchemaConnection());
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(CargoTypesValidationEventHandler);
            using (XmlReader reader = XmlReader.Create(GetCargoTypesConnection(), settings))
            {
                var id = 0;
                var typeName = string.Empty;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "typeId":
                                reader.Read();
                                id = Convert.ToInt32(reader.Value);
                                break;
                            case "typeName":
                                reader.Read();
                                typeName = Convert.ToString(reader.Value);
                                cargoTypes.Add(new CargoType(id, typeName));
                                break;
                        }
                    }
                }
            }
            return cargoTypes;
        }

        private void CargoTypesValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw new SchemaValidationException(e.Message);
        }
    }
}
