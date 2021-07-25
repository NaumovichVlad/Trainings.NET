using CarFleetLib.Cargos.Entities;

namespace CarFleetLib.Cargos.Factories
{
    /// <summary>
    /// Class for creating an instance of the cheese
    /// </summary>
    public class CheeseCreator : CargoCreator, ICheeseCreator
    {
        public override ICargo CreateCargo(int id, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
        {
            return new Cheese(id, weight, volume, optimalStorageTemperature, isLiquid);
        }
    }
}
