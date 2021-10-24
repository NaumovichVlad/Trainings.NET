using CarFleetLib.Cargos.Entities;
using CarFleetLib.Trailers.Entities;
using CarFleetLib.Trailers.Factories;
using CarFleetLib.Trucks.Entities;
using ExceptionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;
using CarFleetLib.Trucks.Factories;

namespace CarFleetLib.FileProcessor
{
    /// <summary>
    /// Class for reading trucks data with XmlReader/XmlWriter
    /// </summary>
    public class TrucksXml : Connection, IRepository<ITruck>
    {
        public void Save(List<ITruck> trucks)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(GetTrucksConnection(), settings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("trucks");
                foreach (var truck in trucks)
                {
                    SaveState(truck);
                    xmlWriter.WriteStartElement("truck");
                    xmlWriter.WriteStartElement("truckId");
                    xmlWriter.WriteString(truck.TruckId.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("truckBrand");
                    xmlWriter.WriteString(truck.TruckBrand);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("registerNumber");
                    xmlWriter.WriteString(truck.RegisterNumber);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("loadCapacity");
                    xmlWriter.WriteString(truck.LoadCapacity.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("fuelConsamption");
                    xmlWriter.WriteString(truck.FuelConsumption.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("fuelConsamptionPerTonOfCargo");
                    xmlWriter.WriteString(truck.FuelConsumptionPerTonOfCargo.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteStartElement("trailerId");
                    xmlWriter.WriteString(truck.TrailerId.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }

        private void SaveState(ITruck truck)
        {
            if (truck.TrailerId != 0)
            {
                IRepository<ITrailer> trailersXml = new TrailersXml();
                var trailers = trailersXml.Load();
                var trailer = trailers.Find(t => t.TrailerId == truck.TrailerId);
                trailer = truck.UnhookTrailer();
                trailersXml.Save(trailers);
            }
        }
        public List<ITruck> Load()
        {
            var trucks = new List<ITruck>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, GetTrucksSchemaConnection());
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(CargosValidationEventHandler);
            using (XmlReader reader = XmlReader.Create(GetTrucksConnection(), settings))
            {
                var truckId = 0;
                var trailerId = 0;
                double loadCapacity = 0;
                double fuelConsumption = 0;
                double fuelConsumptionPerTon = 0;
                var truckBrand = string.Empty;
                var registerNumber = string.Empty;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "truckId":
                                reader.Read();
                                truckId = Convert.ToInt32(reader.Value);
                                break;
                            case "truckBrand":
                                reader.Read();
                                truckBrand = reader.Value;
                                break;
                            case "registerNumber":
                                reader.Read();
                                registerNumber = reader.Value;
                                break;
                            case "loadCapacity":
                                reader.Read();
                                loadCapacity = Convert.ToDouble(reader.Value);
                                break;
                            case "fuelConsamption":
                                reader.Read();
                                fuelConsumption = Convert.ToDouble(reader.Value);
                                break;
                            case "fuelConsamptionPerTonOfCargo":
                                reader.Read();
                                fuelConsumptionPerTon = Convert.ToDouble(reader.Value);
                                break;
                            case "trailerId":
                                reader.Read();
                                var truckCreator = new TruckCreator();
                                var truck = truckCreator.CreateTruck(truckId, truckBrand, registerNumber, loadCapacity,
                                    fuelConsumption, fuelConsumptionPerTon);
                                if (reader.Value != null)
                                {
                                    trailerId = Convert.ToInt32(reader.Value);
                                    var trailer = GetTrailerById(trailerId);
                                    if (trailer != null)
                                        truck.AttachTrailer(trailer);
                                }
                                trucks.Add(truck);
                                break;
                        }
                    }
                }
            }
            return trucks;
        }

        private ITrailer GetTrailerById(int trailerId)
        {
            IRepository<ITrailer> trailerXml = new TrailersXml();
            var trailers = trailerXml.Load();
            var trailer = trailers.Find(t => t.TrailerId == trailerId);
            return trailer;
        }

        private void CargosValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw new SchemaValidationException(e.Message);
        }
    }
}
