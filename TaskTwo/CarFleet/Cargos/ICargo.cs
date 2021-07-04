using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.Cargos
{
    public interface ICargo
    {
        double Weight { get; set; }
        double Volume { get; set; }

        string GetCargoType();
        CargoCategories GetCargoCategory();
    }
}
