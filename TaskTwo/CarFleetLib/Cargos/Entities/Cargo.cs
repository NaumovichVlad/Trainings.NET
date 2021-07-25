using System;

namespace CarFleetLib.Cargos.Entities
{
    /// <summary>
    /// Abstract object for storing cargo data
    /// </summary>
    abstract public class Cargo : ICargo
    {
        /// <summary>
        /// Cargo id
        /// </summary>
        public int CargoId { get; set; }
        /// <summary>
        /// Cargo weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Cargo volume
        /// </summary>
        public double Volume { get; set; }
        /// <summary>
        /// Optimal temperature for cargo storage
        /// </summary>
        public double OptimalStorageTemperature { get; private set; }
        /// <summary>
        /// For checking perishable cargo
        /// </summary>
        public bool IsPerishable { get; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsLiquid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cargoId"></param>
        /// <param name="weight"></param>
        /// <param name="volume"></param>
        /// <param name="temperature"></param>
        /// <param name="isLiquid"></param>
        public Cargo (int cargoId, double weight, double volume, double temperature, bool isLiquid)
        {
            CargoId = cargoId;
            Weight = weight;
            Volume = volume;
            OptimalStorageTemperature = temperature;
            IsPerishable = true;
            IsLiquid = isLiquid;
        }

        /// <summary>
        /// Getting type of cargo
        /// </summary>
        /// <returns>enum cargo type</returns>
        abstract public CargoTypes GetCargoType();
        /// <summary>
        /// Getting category of cargo
        /// </summary>
        /// <returns>Enum cargo category</returns>
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
