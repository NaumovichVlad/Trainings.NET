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
            var cargosXml = new CargosXml();
            cargosXml.Save(cargos);
        }
    }
}
