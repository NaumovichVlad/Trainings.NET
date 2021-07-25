namespace CarFleetLib.Cargos.Entities
{
    /// <summary>
    /// Brick object
    /// </summary>
    public class Brick : MaterialCargo
    {
        /// <summary>
        /// Board parameters
        /// </summary>
        /// <param name="cargoId">Brick Id</param>
        /// <param name="weight">Brick weight</param>
        /// <param name="volume">Brick volume</param>
        /// <param name="optimalStorageTemperature">Optimal temperature for Brick storage</param>
        /// <param name="isLiquid">State of the substance</param>
        public Brick(int cargoId, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }
        /// <summary>
        /// Getting the type of cargo
        /// </summary>
        /// <returns>Enum type</returns>
        public override CargoTypes GetCargoType()
        {
            return CargoTypes.Brick;
        }
    }
}
