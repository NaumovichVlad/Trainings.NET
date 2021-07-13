namespace CarFleetLib.Cargos.Entities
{
    public class Board : MaterialCargo
    {
        public Board(int cargoId, double weight, double volume,
            double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }

        public override ConcreteCargo GetCargoType()
        {
            return ConcreteCargo.Board;
        }
    }
}
