using CarFleet.Cargos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CarFleet.FileProcessor
{
    public class CargoTypesXml : Connection, IRepository<ICargoType>
    {
        public void Create(ICargoType cargoType)
        {
            using (StreamWriter streamWriter = new StreamWriter(GetCargoTypesConnection(), true))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                settings.OmitXmlDeclaration = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter, settings))
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
            }
        }

        public List<ICargoType> Read()
        {
            var cargoTypes = new List<ICargoType>();
            using (XmlReader reader = XmlReader.Create(GetCargoTypesConnection()))
            {
                while (reader.Read())
                {
                    //В разработочке
                }
            }
            return cargoTypes;
        }
    }
}
