using CarFleetLib.Trailers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Entities
{
    public interface ITruck
    {
        int TruckId { get; set; }
        string TruckBrand { get; set; }
        string RegisterNumber { get; set; }
        double LoadCapacity {  get; set;}
        double FuelConsumption { get; set; }
        double FuelConsumptionPerTonOfCargo {  get; set; }

        double GetFuelConsumptionWithCargo();

        TruckCategories GetTruckCategory();
    }
}
