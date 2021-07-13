using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.Cargos.Entities
{
    public interface ICargo
    {
        int CargoId { get; set; }
        double Weight { get; set; }
        double Volume { get; set; }
        double OptimalStorageTemperature { get; }
        bool IsPerishable { get; }
        bool IsLiquid { get;}

        ConcreteCargo GetCargoType();
        CargoCategories GetCargoCategory();
    }
}
