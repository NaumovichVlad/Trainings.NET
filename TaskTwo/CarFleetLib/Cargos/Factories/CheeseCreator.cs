using CarFleetLib.Cargos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos.Factories
{
    public class CheeseCreator : CargoCreator, ICheeseCreator
    {
        public override ICargo CreateCargo(int id, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
        {
            return new Cheese(id, weight, volume, optimalStorageTemperature, isLiquid);
        }
    }
}
