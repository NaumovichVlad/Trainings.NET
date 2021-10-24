using CarFleetLib.Trucks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Factories
{
    public interface ITruckCreator
    {
        ITruck CreateTruck(int truckId, string truckBrand, string registerNumber,
            double loadCapacity, double fuelConsumption, double fuelConsumptionPerTonOfCargo);
    }
}
