using CarFleetLib.Cargos.Entities;
using ExceptionsLib;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos.Factories
{
    public class MaterialsCargoCreator : CargoCreator
    {
        string type = string.Empty;
        IKernel container = new StandardKernel(new MaterialsCargoContainer());

        public MaterialsCargoCreator(string type)
        {
            this.type = type;
        }
        public override ICargo CreateCargo(int id, double weight, double volume,
            double optimalStorageTemperature, bool isLiquid)
        {
            CargoTypes cargoType;
            ICargoCreator cargoCreator;
            if (!Enum.TryParse(type, out cargoType))
                throw new ObjectExistenceException();
            switch (cargoType)
            {
                case CargoTypes.Brick:
                    cargoCreator = container.Get<IBrickCreator>();
                    break;
                case CargoTypes.Board:
                    cargoCreator = container.Get<IBoardCreator>();
                    break;
                case CargoTypes.Glass:
                    cargoCreator = container.Get<IGlassCreator>();
                    break;
                default:
                    throw new ObjectExistenceException();
            }
            return cargoCreator.CreateCargo(id, weight, volume, optimalStorageTemperature, isLiquid);
        }
    }
}
