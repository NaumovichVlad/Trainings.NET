using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.Cargos.Entities
{
    public class Gas : ChemistryCargo
    {
        public Gas(int cargoId, double weight, double volume,
            double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }

        public override ConcreteCargo GetCargoType()
        {
            return ConcreteCargo.Gas;
        }
    }
}
