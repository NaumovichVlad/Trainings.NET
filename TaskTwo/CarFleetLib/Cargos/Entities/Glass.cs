namespace CarFleetLib.Cargos.Entities
{
    public class Glass : MaterialCargo
    {
        public Glass(int cargoId, double weight, double volume,
            double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }

        public override CargoTypes GetCargoType()
        {
            return CargoTypes.Glass;
        }
    }
}
