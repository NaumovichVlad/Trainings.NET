using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos
{
    abstract public class Cargo : ICargo
    {
        public double Weight { get; set; }
        public double Volume { get; set; }

        public Cargo (double weight, double volume)
        {
            Weight = weight;
            Volume = volume;
        }

        abstract public string GetCargoType();
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
                    GetCargoCategory() == cargo.GetCargoCategory())
                {
                    flag = true;
                }
            }
            return flag;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Weight, Volume, GetCargoType());
        }
    }
}
