namespace CarFleetLib.Cargos.Entities
{
    public interface ICargo
    {
        int CargoId { get; set; }
        double Weight { get; set; }
        double Volume { get; set; }
        double OptimalStorageTemperature { get; }
        bool IsPerishable { get; }
        bool IsLiquid { get;}

        CargoTypes GetCargoType();
        CargoCategories GetCargoCategory();
    }
}
