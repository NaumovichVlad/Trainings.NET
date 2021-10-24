using CarFleetLib.Cargos.Entities;
using CarFleetLib.Cargos.Factories;
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

namespace CarFleetLib.FileProcessor
{
    /// <summary>
    /// Class for reading cargo data with StreamReader/StreamWriter
    /// </summary>
    public class CargosStream : Connection, IRepository<ICargo>
    {
        /// <summary>
        /// Saving cargo data
        /// </summary>
        /// <param name="cargos">Cargos</param>
        public void Save(List<ICargo> cargos)
        {
            using (StreamWriter sw = new StreamWriter(GetCargosConnection()))
            {
                var cargosXml = new XElement("cargos");
                foreach (var cargo in cargos)
                {
                    var cargoXml = new XElement("cargo",
                        new XElement("cargoId", cargo.CargoId),
                        new XElement("cargoType", cargo.GetCargoType()),
                        new XElement("cargoCategoryId", GetCategoryIdByName(cargo.GetCargoCategory().ToString())),
                        new XElement("weight", cargo.Weight),
                        new XElement("volume", cargo.Volume),
                        new XElement("optimalStorageTemperature", cargo.OptimalStorageTemperature),
                        new XElement("isLiquid", cargo.IsLiquid)
                    );
                    cargosXml.Add(cargoXml);
                }
                var data = new XDocument(cargosXml);
                sw.Write(data);
            }
        }

        /// <summary>
        /// Reading cargo data from an xml file
        /// </summary>
        /// <returns>Cargo</returns>
        public List<ICargo> Load()
        {
            var cargos = new List<ICargo>();
            using (StreamReader sr = new StreamReader(GetCargosConnection()))
            {
                XDocument data = XDocument.Load(sr);
                foreach (var cargo in data.Element("cargos").Elements("cargo"))
                {
                    var cargoId = Convert.ToInt32(cargo.Element("cargoId").Value);
                    var cargoType = cargo.Element("cargoType").Value;
                    var cargoCategory = GetCategoryById(Convert.ToInt32(cargo.Element("cargoCategoryId").Value));
                    var weight = Convert.ToDouble(cargo.Element("weight").Value);
                    var volume = Convert.ToDouble(cargo.Element("volume").Value);
                    var optimalStorageTemperature = Convert.ToDouble(cargo.Element("optimalStorageTemperature").Value);
                    var isLiquid = Convert.ToBoolean(cargo.Element("isLiquid").Value);
                    var cargoCreator = new ConcreteCargoCreator(cargoCategory, cargoType);
                    cargos.Add(cargoCreator.CreateCargo(cargoId, weight, volume, optimalStorageTemperature, isLiquid));
                }

            }            
            return cargos;
        }

        private string GetCategoryById(int categoryId)
        {
            var categoryName = string.Empty;
            using (StreamReader sr = new StreamReader(GetCargoCategoriesConnection()))
            {
                var data = XDocument.Load(sr);
                var categories = data.Element("cargoCategories").Elements("cargoCategory");
                var category = categories.First(c => c.Element("categoryId").Value == categoryId.ToString());
                categoryName = category.Element("categoryName").Value;
            }
            return categoryName;
        }

        private int GetCategoryIdByName(string categoryName)
        {
            var categoryId = 0;
            using (StreamReader sr = new StreamReader(GetCargoCategoriesConnection()))
            {
                var data = XDocument.Load(sr);
                var categories = data.Element("cargoCategories").Elements("cargoCategory");
                var category = categories.First(c => c.Element("categoryName").Value == categoryName);
                categoryId = Convert.ToInt32(category.Element("categoryId").Value);
            }
            return categoryId;
        }

        private void CargosValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw new SchemaValidationException(e.Message);
        }
    }
}
