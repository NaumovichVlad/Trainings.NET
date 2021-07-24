using CarFleetLib.Cargos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos.Factories
{
    public class MilkCreator : CargoCreator, IMilkCreator
    {
        public override ICargo CreateCargo(int id, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
        {
            return new Milk(id, weight, volume, optimalStorageTemperature, isLiquid);
        }
    }
}
