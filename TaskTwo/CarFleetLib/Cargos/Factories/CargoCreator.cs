using CarFleetLib.Cargos.Entities;

namespace CarFleetLib.Cargos.Factories
{
    /// <summary>
    /// A class for creating instances at the lowest level
    /// </summary>
    abstract public class CargoCreator : ICargoCreator
    {
        abstract public ICargo CreateCargo(int id, double weight, double volume,
            double optimalStorageTemperature, bool isLiquid);
    }
}
