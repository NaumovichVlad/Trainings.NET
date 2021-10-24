using CarFleetLib.Cargos.Entities;
using CarFleetLib.Cargos.Factories;
using CarFleetLib.FileProcessor;
using CarFleetLib.Trailers.Entities;
using CarFleetLib.Trailers.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLibTests
{
    internal class FillerForTests
    {
        internal void FillFiles()
        {
            FillCargosXml();
        }

        internal void FillCargosXml()
        {
            var cargos = new List<ICargo>();
            var creator = new ConcreteCargoCreator("Products", "Milk");
            cargos.Add(creator.CreateCargo(1, 10, 10, 2, false));
            creator = new ConcreteCargoCreator("Products", "Meat");
            cargos.Add(creator.CreateCargo(2, 30, 10, -15, false));
            creator = new ConcreteCargoCreator("Products", "Chease");
            cargos.Add(creator.CreateCargo(3, 10, 10, 2, false));
            creator = new ConcreteCargoCreator("Materials", "Brick");
            cargos.Add(creator.CreateCargo(4, 10, 10, 20, false));
            creator = new ConcreteCargoCreator("Materials", "Glass");
            cargos.Add(creator.CreateCargo(4, 10, 10, 20, false));
            creator = new ConcreteCargoCreator("Materials", "Board");
            cargos.Add(creator.CreateCargo(4, 10, 10, 20, false));
            creator = new ConcreteCargoCreator("Chemistry", "Gas");
            cargos.Add(creator.CreateCargo(4, 10, 10, 20, true));
            creator = new ConcreteCargoCreator("Chemistry", "Petrol");
            cargos.Add(creator.CreateCargo(4, 10, 10, 20, true));
            creator = new ConcreteCargoCreator("Chemistry", "Fuel");
            cargos.Add(creator.CreateCargo(4, 10, 10, 20, true));
            var cargosXml = new CargosXml();
            cargosXml.Save(cargos);
        }
    }
}
