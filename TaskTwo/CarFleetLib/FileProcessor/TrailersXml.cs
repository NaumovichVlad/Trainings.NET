using CarFleetLib.Cargos.Entities;
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
    /// <summary>
    /// Class for reading trailer data with XmlReader/XmlWriter
    /// </summary>
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
                    CreateInvoicesByCargo(trailer);
                    xmlWriter.WriteStartElement("trailer");
                    xmlWriter.WriteStartElement("trailerId");
                    xmlWriter.WriteString(trailer.TrailerId.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("trailerCategoryId");
                    xmlWriter.WriteString(GetCategoryIdByName(trailer.GetTrailerType().ToString()).ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("loadCapacity");
                    xmlWriter.WriteString(trailer.LoadСapacity.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("volume");
                    xmlWriter.WriteString(trailer.Volume.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("weight");
                    xmlWriter.WriteString(trailer.OwnWeight.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }

        private void CreateInvoicesByCargo(ITrailer trailer)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(GetInvoicesConnection(), settings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("invoices");
                var trailerId = trailer.TrailerId;
                var cargos = trailer.UnloadCargo();
                if (cargos != null)
                {
                    var devidedCargos = DevideCargoById(cargos);
                    foreach (var devidedCargo in devidedCargos)
                    {
                        var quantity = devidedCargo.Count;
                        xmlWriter.WriteStartElement("invoice");
                        xmlWriter.WriteStartElement("trailerId");
                        xmlWriter.WriteString(trailerId.ToString());
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteStartElement("cargoId");
                        xmlWriter.WriteString(devidedCargo[0].CargoId.ToString());
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteStartElement("cargoQuantity");
                        xmlWriter.WriteString(quantity.ToString());
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndElement();
                    }
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
            }
        }

        private List<List<ICargo>> DevideCargoById(List<ICargo> cargos)
        {
            var devidedCargo = new List<List<ICargo>>();
            var ids = new List<int>();
            foreach (var cargo in cargos)
            {
                if (!ids.Contains(cargo.CargoId))
                {
                    ids.Add(cargo.CargoId);
                    var tmpCargos = cargos.Where(c => c.CargoId == cargo.CargoId).ToList();
                    devidedCargo.Add(tmpCargos);
                }
            }
            return devidedCargo;
        }

        private string GetCategoryById(int categoryId)
        {
            var categoryName = string.Empty;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, GetTrailerCategoriesSchemaConnection());
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(CargosValidationEventHandler);
            using (XmlReader reader = XmlReader.Create(GetTrailerCategoriesConnection(), settings))
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
            settings.Schemas.Add(null, GetTrailerCategoriesSchemaConnection());
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(CargosValidationEventHandler);
            using (XmlReader reader = XmlReader.Create(GetTrailerCategoriesConnection(), settings))
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

        public List<ITrailer> Load()
        {
            var trailers = new List<ITrailer>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, GetTrailersSchemaConnection());
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(CargosValidationEventHandler);
            using (XmlReader reader = XmlReader.Create(GetTrailersConnection(), settings))
            {
                var trailerId = 0;
                var categoryId = 0;
                double weight = 0;
                double volume = 0;
                double loadCapacity = 0;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "trailerId":
                                reader.Read();
                                trailerId = Convert.ToInt32(reader.Value);
                                break;
                            case "trailerCategoryId":
                                reader.Read();
                                categoryId = Convert.ToInt32(reader.Value);
                                break;
                            case "volume":
                                reader.Read();
                                volume = Convert.ToDouble(reader.Value);
                                break;
                            case "loadCapacity":
                                reader.Read();
                                loadCapacity = Convert.ToDouble(reader.Value);
                                break;
                            case "weight":
                                reader.Read();
                                weight = Convert.ToDouble(reader.Value);
                                var category = GetCategoryById(categoryId);
                                var trailerCreator = new TrailerCreator();
                                var trailer = trailerCreator.CreateTrailer(trailerId, loadCapacity, volume, weight, category);
                                var cargosForLoad = GetCargosByInvoices(trailerId);
                                if (cargosForLoad.Count != 0)
                                    trailer.LoadCargo(cargosForLoad);
                                trailers.Add(trailer);
                                break;
                        }
                    }
                }
            }
            return trailers;
        }

        private List<ICargo> GetCargosByInvoices(int trailerId)
        {
            var cargos = new List<ICargo>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, GetInvoicesSchemaConnection());
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(CargosValidationEventHandler);
            using (XmlReader reader = XmlReader.Create(GetInvoicesConnection(), settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "trailerId")
                        {
                            reader.Read();
                            if(reader.Value == trailerId.ToString())
                            {
                                while (reader.Name != "cargoId")
                                    reader.Read();
                                reader.Read();
                                var cargoId = Convert.ToInt32(reader.Value);
                                while (reader.Name != "cargoQuantity")
                                    reader.Read();
                                var quantity = Convert.ToInt32(reader.Value);
                                var cargo = GetCargoById(cargoId);
                                for (var i = 0; i < quantity; i++)
                                    cargos.Add(cargo);
                            }
                        }
                    }
                }
            }
            return cargos;
        }

        private ICargo GetCargoById(int cargoId)
        {
            IRepository<ICargo> cargoReader = new CargosXml();
            var cargos = cargoReader.Load();
            ICargo cargo = cargos.Find(c => c.CargoId == cargoId);
            return cargo;
        }

        private void CargosValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw new SchemaValidationException(e.Message);
        }
    }
}
