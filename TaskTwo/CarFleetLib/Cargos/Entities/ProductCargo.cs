namespace CarFleetLib.Cargos.Entities
{
    abstract public class ProductCargo : Cargo
    {
        public ProductCargo(int cargoId, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }

        public override CargoCategories GetCargoCategory()
        {
            return CargoCategories.Products;
        }
    }
}
