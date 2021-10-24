namespace CarFleetLib.Cargos.Entities
{
    public class Cheese : ProductCargo
    {
        public Cheese(int cargoId, double weight, double volume,
            double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }

        public override CargoTypes GetCargoType()
        {
            return CargoTypes.Cheese;
        }
    }
}
