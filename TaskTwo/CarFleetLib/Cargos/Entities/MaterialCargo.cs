namespace CarFleetLib.Cargos.Entities
{
    public abstract class MaterialCargo : Cargo
    {
        public MaterialCargo(int cargoId, double weight, double volume, double optimalStorageTemperature, bool isLiquid)
            : base(cargoId, weight, volume, optimalStorageTemperature, isLiquid)
        { }

        public override CargoCategories GetCargoCategory()
        {
            return CargoCategories.Materials;
        }
    }
}
