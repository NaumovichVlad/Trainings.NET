using CarFleet.Cargos;
using System;
using System.Collections.Generic;
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
            using (XmlWriter writer = XmlWriter.Create("cargoTypes.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("cargoTypes");
                writer.WriteStartElement("cargoType");
                writer.WriteStartElement("typeId");
                writer.WriteString(cargoType.TypeId.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("typeName");
                writer.WriteString(cargoType.TypeName);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
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
