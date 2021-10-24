namespace CarFleetLib.Cargos.Entities
{
    public class Gas : ChemistryCargo
    {
        public Gas(int cargoId, double weight, double volume,
            double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }

        public override CargoTypes GetCargoType()
        {
            return CargoTypes.Gas;
        }
    }
}
