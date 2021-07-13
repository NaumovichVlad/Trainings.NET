using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleet.Cargos.Entities;
using ExceptionsLib;

namespace CarFleet.Cargos.Factories
{
    public class ConcreteCargoCreator : CargoCreator
    {
        int id;
        double weight, volume, optimalStorageTemperature;
        string category, type;
        bool isLiquid;
        public ConcreteCargoCreator (int id, double weight, double volume,
            string category, string type, double optimalStorageTemperature, bool isLiquid)
        {
            this.id = id;
            this.weight = weight;
            this.volume = volume;
            this.optimalStorageTemperature = optimalStorageTemperature;
            this.category = category;
            this.type = type;
            this.isLiquid = isLiquid;
        }

        public override ICargo CreateCargo()
        {
            CargoCategories cargoCategory;
            ICargoCreator cargoCreator = null;
            if (!Enum.TryParse(category, out cargoCategory))
                throw new ObjectExistenceException();
            switch (cargoCategory)
            {
                case CargoCategories.Products:
                    cargoCreator = new ProductsCargoCreator(id, weight, volume, type, optimalStorageTemperature, isLiquid);
                    break;
                case CargoCategories.Chemistry:
                    cargoCreator = new ChemistryCargoCreator(id, weight, volume, type, optimalStorageTemperature, isLiquid);
                    break;
                case CargoCategories.Materials:
                    cargoCreator = new MaterialsCargoCreator(id, weight, volume, type, optimalStorageTemperature, isLiquid);
                    break;
            }
            ICargo cargo = cargoCreator.CreateCargo();
            return cargo;
        }
    }
}
