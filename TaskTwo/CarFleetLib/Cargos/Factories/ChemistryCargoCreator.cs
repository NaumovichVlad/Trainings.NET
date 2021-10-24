using CarFleetLib.Cargos.Entities;
using ExceptionsLib;
using Ninject;
using System;

namespace CarFleetLib.Cargos.Factories
{
    /// <summary>
    /// Factory for create chemistry cargo
    /// </summary>
    public class ChemistryCargoCreator : CargoCreator
    {
        string type = string.Empty;
        IKernel container = new StandardKernel(new ChemistryCargoContainer());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">Chemistry type</param>
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
