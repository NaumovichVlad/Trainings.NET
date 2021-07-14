using CarFleetLib.Cargos.Categories;
using CarFleetLib.Cargos.Entities;
using CarFleetLib.Cargos.Factories;
using CarFleetLib.FileProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLibTests
{
    internal class FillerForTests : Connection
    {
        internal void FillAllFiles()
        {
            FillCargoCategoriesXml();
            FillCargosXml();
        }

        internal void FillCargoCategoriesXml()
        {
            var creator = new CargoCategoryCreator();
            var cargoCategories = new List<ICargoCategory>() {
                creator.CreateCategory("Products", 1),
                creator.CreateCategory("Materials", 2),
                creator.CreateCategory("Chemistry", 3)
            };
            var categoryXml = new CargoCategoriesXml();
            categoryXml.Save(cargoCategories);
        }

        internal void FillCargosXml()
        {
            var cargos = new List<ICargo>();
            var creator = new ConcreteCargoCreator(1, 10, 10, "Products", "Milk", 2, false);
            cargos.Add(creator.CreateCargo());
            creator = new ConcreteCargoCreator(2, 30, 10, "Products", "Meat", -15, false);
            cargos.Add(creator.CreateCargo());
            creator = new ConcreteCargoCreator(3, 10, 10, "Products", "Chease", 2, false);
            cargos.Add(creator.CreateCargo());
            var cargosXml = new CargosXml();
            cargosXml.Save(cargos);
        }
    }
}
