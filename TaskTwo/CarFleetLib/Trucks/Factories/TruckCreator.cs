using CarFleetLib.Trucks.Entities;
using ExceptionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Factories
{
    public class TruckCreator : ITruckCreator
    {
        public ITruck CreateTruck(int truckId, string truckBrand, string registerNumber,
            double loadCapacity, double fuelConsumption, double fuelConsumptionPerTonOfCargo)
        {
            return new TruckTractor(truckId, truckBrand, registerNumber, loadCapacity, fuelConsumption, fuelConsumptionPerTonOfCargo);
        }
    }
}
