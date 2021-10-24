using CarFleetLib.Cargos.Entities;
using CarFleetLib.Trailers.Entities;
using CarFleetLib.Trailers.Factories;
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
using CarFleetLib.Cargos.Factories;

namespace CarFleetLib.FileProcessor
{
    /// <summary>
    /// Class for reading trailers data with StreamReader/StreamWriter
    /// </summary>
    public class TrailersStream : Connection, IRepository<ITrailer>
    {
        public void Save(List<ITrailer> trailers)
        {
            using (StreamWriter sw = new StreamWriter(GetTrailersConnection()))
            {
                var trailersXml = new XElement("trailers");
                foreach (var trailer in trailers)
                {
                    CreateInvoicesByCargo(trailer);
                    var trailerXml = new XElement("trailer",
                        new XElement("trailerId", trailer.TrailerId),
                        new XElement("trailerCategoryId", GetCategoryIdByName(trailer.GetTrailerType().ToString())),
                        new XElement("loadCapacity", trailer.LoadСapacity),
                        new XElement("volume", trailer.Volume),
                        new XElement("weight", trailer.OwnWeight)
                    );
                    trailersXml.Add(trailerXml);
                }
                var data = new XDocument(trailersXml);
                sw.Write(data);
            }
        }

        private void CreateInvoicesByCargo(ITrailer trailer)
        {
            using (StreamWriter sw = new StreamWriter(GetInvoicesConnection()))
            {
                var invoicesXml = new XElement("invoices");
                var trailerId = trailer.TrailerId;
                var cargos = trailer.UnloadCargo();
                if (cargos != null)
                {
                    var devidedCargos = DevideCargoById(cargos);
                    foreach (var devidedCargo in devidedCargos)
                    {
                        var quantity = devidedCargo.Count;
                        var trailerXml = new XElement("invoice",
                            new XElement("trailerId", trailer.TrailerId),
                            new XElement("cargoId", devidedCargo[0].CargoId),
                            new XElement("cargoQuantity", quantity)
                        );
                        invoicesXml.Add(trailerXml);
                    }
                }
                var data = new XDocument(invoicesXml);
                sw.Write(data);
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
            using (StreamReader sr = new StreamReader(GetTrailerCategoriesConnection()))
            {
                var data = XDocument.Load(sr);
                var categories = data.Element("trailerCategories").Elements("trailerCategory");
                var category = categories.First(c => c.Element("categoryId").Value == categoryId.ToString());
                categoryName = category.Element("categoryName").Value;
            }
            return categoryName;

        }

        private int GetCategoryIdByName(string categoryName)
        {
            var categoryId = 0;
            using (StreamReader sr = new StreamReader(GetTrailerCategoriesConnection()))
            {
                var data = XDocument.Load(sr);
                var categories = data.Element("trailerCategories").Elements("trailerCategory");
                var category = categories.First(c => c.Element("categoryName").Value == categoryName);
                categoryId = Convert.ToInt32(category.Element("categoryId").Value);
            }
            return categoryId;
        }

        public List<ITrailer> Load()
        {
            var trailers = new List<ITrailer>();
            using (StreamReader sr = new StreamReader(GetTrailersConnection()))
            {
                XDocument data = XDocument.Load(sr);
                foreach (var trailer in data.Element("trailers").Elements("trailer"))
                {
                    var trailerId = Convert.ToInt32(trailer.Element("trailerId").Value);
                    var trailerCategoryId = Convert.ToInt32(trailer.Element("trailerCategoryId").Value);
                    var weight = Convert.ToDouble(trailer.Element("weight").Value);
                    var volume = Convert.ToDouble(trailer.Element("volume").Value);
                    var loadCapacity = Convert.ToDouble(trailer.Element("loadCapacity").Value);
                    var category = GetCategoryById(trailerCategoryId);
                    var trailerCreator = new TrailerCreator();
                    var newTrailer = trailerCreator.CreateTrailer(trailerId, loadCapacity, volume, weight, category);
                    var cargosForLoad = GetCargosByInvoices(trailerId);
                    if (cargosForLoad.Count != 0)
                        newTrailer.LoadCargo(cargosForLoad);
                    trailers.Add(newTrailer);
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
                            if (reader.Value == trailerId.ToString())
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
