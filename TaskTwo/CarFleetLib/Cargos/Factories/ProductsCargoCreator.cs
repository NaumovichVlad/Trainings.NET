using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleetLib.Cargos.Entities;
using ExceptionsLib;
using Ninject;

namespace CarFleetLib.Cargos.Factories
{
    public class ProductsCargoCreator : CargoCreator
    {
        string type = string.Empty;
        IKernel container = new StandardKernel(new ProductsCargoContainer());
        public ProductsCargoCreator(string type)
        {
            this.type = type;
        }
        public override ICargo CreateCargo(int id, double weight, double volume,
            double optimalStorageTemperature, bool isLiquid)
        {
            CargoTypes cargoType;
            ICargoCreator cargoCreator;
            if(!Enum.TryParse(type, out cargoType))
                throw new ObjectExistenceException();
            switch (cargoType)
            {
                case CargoTypes.Cheese:
                    cargoCreator = container.Get<ICheeseCreator>();
                    break;
                case CargoTypes.Meat:
                    cargoCreator = container.Get<IMeatCreator>();
                    break;
                case CargoTypes.Milk:
                    cargoCreator = container.Get<IMilkCreator>();  
                    break;
                default:
                    throw new ObjectExistenceException();
            }
            var cargo = cargoCreator.CreateCargo(id, weight, volume, optimalStorageTemperature, isLiquid);
            return cargo;
        }
    }
}
