namespace CarFleetLib.Cargos.Entities
{

    public class Brick : MaterialCargo
    {
        public Brick(int cargoId, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }

        public override CargoTypes GetCargoType()
        {
            return CargoTypes.Brick;
        }
    }
}
