namespace CarFleetLib.Cargos.Entities
{

    public class Brick : MaterialCargo
    {
        public Brick(int cargoId, double weight, double volume, bool isLiquid)
            : base(cargoId, weight, volume, isLiquid)
        { }

        public override CargoTypes GetCargoType()
        {
            return CargoTypes.Brick;
        }
    }
}
