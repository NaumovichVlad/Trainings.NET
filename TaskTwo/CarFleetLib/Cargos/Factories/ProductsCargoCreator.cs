using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleetLib.Cargos.Entities;
using ExceptionsLib;

namespace CarFleetLib.Cargos.Factories
{
    public class ProductsCargoCreator : CargoCreator
    {
        int id;
        double weight, volume;
        string type;
        double optimalStorageTemperature;
        bool isLiquid;

        public ProductsCargoCreator(int id, double weight, double volume,
            string type, double optimalStorageTemperature, bool isLiquid)
        {
            this.id = id;
            this.weight = weight;
            this.volume = volume;
            this.type = type;
            this.optimalStorageTemperature = optimalStorageTemperature;
            this.isLiquid = isLiquid;

        }
        public override ICargo CreateCargo()
        {
            ConcreteCargo cargoType;
            ICargo cargo = null;
            if(!Enum.TryParse(type, out cargoType))
                throw new ObjectExistenceException();
            switch (cargoType)
            {
                case ConcreteCargo.Chease:
                    cargo = new Chease(id, weight, volume, optimalStorageTemperature, isLiquid);
                    break;
                case ConcreteCargo.Meat:
                    cargo = new Meat(id, weight, volume, optimalStorageTemperature, isLiquid);
                    break;
                case ConcreteCargo.Milk:
                    cargo = new Milk(id, weight, volume, optimalStorageTemperature, isLiquid);
                    break;
                default:
                    throw new ObjectExistenceException();
            }
            return cargo;
        }
    }
}
