using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Entities
{
    abstract public class Truck : ITruck
    {
        public int TruckId { get; set; }
        public string TruckBrand { get; set; }
        public string RegisterNumber { get; set; }
        public double LoadCapacity { get; set; }
        public double FuelConsumption { get; set; }
        public double FuelConsumptionPerTonOfCargo { get; set; }

        public Truck(int truckId, string truckBrand, string registerNumber, 
            double loadCapacity,  double fuelConsumption, double fuelConsumptionPerTonOfCargo)
        {
            TruckId = truckId;
            TruckBrand = truckBrand;
            RegisterNumber = registerNumber;
            LoadCapacity = loadCapacity;
            FuelConsumption = fuelConsumption;
            FuelConsumptionPerTonOfCargo = fuelConsumptionPerTonOfCargo;
        }
        abstract public double GetFuelConsumptionWithCargo();

        abstract public TruckCategories GetTruckCategory();
    }
}
