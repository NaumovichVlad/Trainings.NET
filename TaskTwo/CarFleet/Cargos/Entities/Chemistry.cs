using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.Cargos.Entities
{
    abstract public class Chemistry : Cargo
    {
        public Chemistry(int cargoId, double weight, double volume, bool isLiquid)
                : base(cargoId, weight, volume, isLiquid)
        { }

        public Chemistry(int cargoId, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }

        public override CargoCategories GetCargoCategory()
        {
            return CargoCategories.Chemistry;
        }
    }
}
