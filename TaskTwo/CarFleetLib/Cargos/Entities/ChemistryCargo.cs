namespace CarFleetLib.Cargos.Entities
{
    abstract public class ChemistryCargo : Cargo
    {
        public ChemistryCargo(int cargoId, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }

        public override CargoCategories GetCargoCategory()
        {
            return CargoCategories.Chemistry;
        }
    }
}
