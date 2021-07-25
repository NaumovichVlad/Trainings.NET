using CarFleetLib.Cargos.Entities;

namespace CarFleetLib.Cargos.Factories
{
    /// <summary>
    /// Interface for factory
    /// </summary>
    public interface ICargoCreator
    {
        ICargo CreateCargo(int id, double weight, double volume,
           double optimalStorageTemperature, bool isLiquid);
    }
}
