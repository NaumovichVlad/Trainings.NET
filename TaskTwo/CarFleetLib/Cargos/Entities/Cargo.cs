using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos.Entities
{
    abstract public class Cargo : ICargo
    {
        public int CargoId { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public double OptimalStorageTemperature { get; private set; }
        public bool IsPerishable { get; }
        public bool IsLiquid { get; set; }


        public Cargo (int cargoId, double weight, double volume, double temperature, bool isLiquid)
        {
            CargoId = cargoId;
            Weight = weight;
            Volume = volume;
            OptimalStorageTemperature = temperature;
            IsPerishable = true;
            IsLiquid = isLiquid;
        }

        public Cargo (int cargoId, double weight, double volume, bool isLiquid)
        {
            CargoId = cargoId;
            Weight = weight;
            Volume = volume;
            IsPerishable = false;
            IsLiquid = isLiquid;
        }

        abstract public CargoTypes GetCargoType();
        abstract public CargoCategories GetCargoCategory();

        public override bool Equals(object obj)
        {
            return Equals(obj as Cargo);
        }

        public bool Equals(Cargo cargo)
        {
            var flag = false;
            if (cargo != null)
            {
                if (Weight == cargo.Weight &&
                    Volume == cargo.Volume &&
                    GetCargoType() == cargo.GetCargoType() &&
                    GetCargoCategory() == cargo.GetCargoCategory() &&
                    OptimalStorageTemperature == cargo.OptimalStorageTemperature &&
                    IsLiquid == cargo.IsLiquid)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Weight, Volume, GetCargoType(), IsLiquid);
        }
    }
}
