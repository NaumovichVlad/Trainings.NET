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
    public class ChemistryCargoCreator : CargoCreator
    {
        string type = string.Empty;
        IKernel container = new StandardKernel(new ChemistryCargoContainer());

        public ChemistryCargoCreator(string type)
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
                case CargoTypes.Gas:
                    cargoCreator = container.Get<IGasCreator>();
                    break;
                case CargoTypes.Petrol:
                    cargoCreator = container.Get<IPetrolCreator>();
                    break;
                case CargoTypes.Diesel:
                    cargoCreator = container.Get<IDieselCreator>();
                    break;
                default:
                    throw new ObjectExistenceException();
            }
            var cargo = cargoCreator.CreateCargo(id, weight, volume, optimalStorageTemperature, isLiquid);
            return cargo;
        }
    }
}
