using CarFleetLib.Cargos.Entities;

namespace CarFleetLib.Cargos.Factories
{
    /// <summary>
    /// Class for creating an instance of the glass
    /// </summary>
    public class GlassCreator : CargoCreator, IGlassCreator
    {
        public override ICargo CreateCargo(int id, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
        {
            return new Glass(id, weight, volume, optimalStorageTemperature, isLiquid);
        }
    }
}
