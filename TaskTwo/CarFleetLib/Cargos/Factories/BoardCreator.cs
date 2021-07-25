using CarFleetLib.Cargos.Entities;

namespace CarFleetLib.Cargos.Factories
{
    /// <summary>
    /// Class for creating an instance of the board 
    /// </summary>
    public class BoardCreator : CargoCreator, IBoardCreator
    {
        public override ICargo CreateCargo(int id, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
        {
            return new Board (id, weight, volume, optimalStorageTemperature, isLiquid);
        }
    }
}
