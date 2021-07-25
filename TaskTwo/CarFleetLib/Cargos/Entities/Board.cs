namespace CarFleetLib.Cargos.Entities
{
    /// <summary>
    /// Board object
    /// </summary>
    public class Board : MaterialCargo
    {
        /// <summary>
        /// Board parameters
        /// </summary>
        /// <param name="cargoId">Board Id</param>
        /// <param name="weight">Board weight</param>
        /// <param name="volume">Board volume</param>
        /// <param name="optimalStorageTemperature">Optimal temperature for board storage</param>
        /// <param name="isLiquid">State of the substance</param>
        public Board(int cargoId, double weight, double volume,
            double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }
        /// <summary>
        /// Getting the type of cargo
        /// </summary>
        /// <returns>Enum type</returns>
        public override CargoTypes GetCargoType()
        {
            return CargoTypes.Board;
        }
    }
}
