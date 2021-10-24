using CarFleetLib.Cargos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos.Factories
{
    /// <summary>
    /// Class for creating an instance of the brick
    /// </summary>
    public class BrickCreator : IBrickCreator
    {
        public ICargo CreateCargo(int id, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
        {
            return new Brick (id, weight, volume, optimalStorageTemperature, isLiquid);
        }
    }
}
