using CarFleetLib.Trailers.Entities;
using CarFleetLib.Trucks.Entities;
using CarFleetLib.Trucks.Factories;
using ExceptionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using CarFleetLib.Cargos.Entities;
using CarFleetLib.Cargos.Factories;

namespace CarFleetLib.FileProcessor
{
    /// <summary>
    /// Class for reading trucks data with StreamReader/StreamWriter
    /// </summary>
    public class TrucksStream : Connection, IRepository<ITruck>
    {
        public void Save(List<ITruck> trucks)
        {
            using (StreamWriter sw = new StreamWriter(GetTrucksConnection()))
            {
                var trucksXml = new XElement("trucks");
                foreach (var truck in trucks)
                {
                    SaveState(truck);
                    var truckXml = new XElement("truck",
                        new XElement("truckId", truck.TruckId),
                        new XElement("truckBrand", truck.TruckBrand),
                        new XElement("registerNumber", truck.RegisterNumber),
                        new XElement("loadCapacity", truck.LoadCapacity),
                        new XElement("fuelConsamption", truck.FuelConsumption),
                        new XElement("fuelConsamptionPerTonOfCargo", truck.FuelConsumptionPerTonOfCargo),
                        new XElement("trailerId", truck.TrailerId)
                    );
                    trucksXml.Add(truckXml);
                }
                var data = new XDocument(trucksXml);
                sw.Write(data);
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
            using (StreamReader sr = new StreamReader(GetTrucksConnection()))
            {
                XDocument data = XDocument.Load(sr);
                foreach (var truckXml in data.Element("trucks").Elements("truck"))
                {
                    var truckId = Convert.ToInt32(truckXml.Element("truckId").Value);
                    var truckBrand = truckXml.Element("truckBrand").Value;
                    var registerNumber = truckXml.Element("registerNumber").Value;
                    var loadCapacity = Convert.ToDouble(truckXml.Element("loadCapacity").Value);
                    var fuelConsamption = Convert.ToDouble(truckXml.Element("fuelConsamption").Value);
                    var fuelConsamptionPerTonOfCargo = Convert.ToDouble(truckXml.Element("fuelConsamptionPerTonOfCargo").Value);
                    var trailerId = Convert.ToInt32(truckXml.Element("trailerId").Value);
                    var trailer = GetTrailerById(trailerId);
                    var truckCreator = new TruckCreator();
                    var truck = truckCreator.CreateTruck(truckId, truckBrand, registerNumber, loadCapacity,
                                    fuelConsamption, fuelConsamptionPerTonOfCargo);
                    if (trailer != null)
                        truck.AttachTrailer(trailer);
                    trucks.Add(truck);
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
