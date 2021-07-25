using System;
using CarFleetLib.Cargos.Entities;
using ExceptionsLib;

namespace CarFleetLib.Cargos.Factories
{
    /// <summary>
    /// Factory for create cargo
    /// </summary>
    public class ConcreteCargoCreator : CargoCreator
    {
        string category = string.Empty;
        string type = string.Empty;
        public ConcreteCargoCreator(string category, string type)
        {
            this.category = category;
            this.type = type;
        }
        public override ICargo CreateCargo(int id, double weight, double volume,
            double optimalStorageTemperature, bool isLiquid)
        {
            CargoCategories cargoCategory;
            ICargoCreator cargoCreator = null;
            if (!Enum.TryParse(category, out cargoCategory))
                throw new ObjectExistenceException();
            switch (cargoCategory)
            {
                case CargoCategories.Products:
                    cargoCreator = new ProductsCargoCreator(type);
                    break;
                case CargoCategories.Chemistry:
                    cargoCreator = new ChemistryCargoCreator(type);
                    break;
                case CargoCategories.Materials:
                    cargoCreator = new MaterialsCargoCreator(type);
                    break;
            }
            ICargo cargo = cargoCreator.CreateCargo(id, weight, volume, optimalStorageTemperature, isLiquid);
            return cargo;
        }
    }
}
