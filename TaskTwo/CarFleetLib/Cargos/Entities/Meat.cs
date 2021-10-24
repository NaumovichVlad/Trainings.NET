namespace CarFleetLib.Cargos.Entities
{
    public class Meat : ProductCargo
    {
        public Meat(int cargoId, double weight, double volume,
            double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }

        public override CargoTypes GetCargoType()
        {
            return CargoTypes.Meat;
        }
    }
}
