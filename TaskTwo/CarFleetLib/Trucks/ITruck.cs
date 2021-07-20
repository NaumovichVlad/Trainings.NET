using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks
{
    public interface ITruck
    {
        int TruckId { get; set; }
        string TruckBrand { get; set; }
        string RegisterNumber { get; set; }

        double GetFuelConsumption();
    }
}
