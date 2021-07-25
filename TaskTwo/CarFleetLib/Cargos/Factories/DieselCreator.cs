using CarFleetLib.Cargos.Entities;

namespace CarFleetLib.Cargos.Factories
{
    /// <summary>
    /// Class for creating an instance of the diesel 
    /// </summary>
    public class DieselCreator : CargoCreator, IDieselCreator
    {
        public override ICargo CreateCargo(int id, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
        {
            return new Diesel(id, weight, volume, optimalStorageTemperature, isLiquid);
        }
    }
}
