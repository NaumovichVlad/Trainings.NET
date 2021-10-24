using CarFleetLib.Cargos.Entities;

namespace CarFleetLib.Cargos.Factories
{
    /// <summary>
    /// Class for creating an instance of the gas
    /// </summary>
    public class GasCreator : CargoCreator, IGasCreator
    {
        public override ICargo CreateCargo(int id, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
        {
            return new Gas(id, weight, volume, optimalStorageTemperature, isLiquid);
        }
    }
}
