using CarFleetLib.Cargos.Entities;
using CarFleetLib.Trailers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Entities
{
    abstract public class Truck : ITruck
    {
        public int TruckId { get; set;}
        public string TruckBrand { get; set; }
        public string RegisterNumber { get; set; }
        public double LoadCapacity { get; set; }
        public double FuelConsumption { get; set; }
        public double FuelConsumptionPerTonOfCargo { get; set; }
        public int TrailerId { get; set; }

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
        abstract public List<ICargo> UnloadCargo();
        abstract public List<ICargo> ShowCargo();
        abstract public void LoadCargo(List<ICargo> cargoList);
        public abstract void AttachTrailer(ITrailer trailer);
        public abstract ITrailer UnhookTrailer();
        public override bool Equals(object obj)
        {
            return Equals(obj as Truck);
        }

        public bool Equals(Truck truck)
        {
            var flag = false;
            if (truck != null)
            {
                if (TruckId == truck.TruckId &&
                    TruckBrand == truck.TruckBrand &&
                    RegisterNumber == truck.RegisterNumber &&
                    LoadCapacity == truck.LoadCapacity &&
                    FuelConsumption == truck.FuelConsumption &&
                    FuelConsumptionPerTonOfCargo == truck.FuelConsumptionPerTonOfCargo &&
                    GetTruckCategory() == truck.GetTruckCategory())
                {
                    flag = true;
                }
            }
            return flag;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TruckId, TruckBrand, RegisterNumber, LoadCapacity, FuelConsumption,
                FuelConsumptionPerTonOfCargo, GetTruckCategory());
        }
    }
}
