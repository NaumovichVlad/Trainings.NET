namespace CarFleetLib.Cargos.Entities
{
    public class Petrol : ChemistryCargo
    {
        public Petrol(int cargoId, double weight, double volume,
            double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }

        public override CargoTypes GetCargoType()
        {
            return CargoTypes.Petrol;
        }
    }
}
