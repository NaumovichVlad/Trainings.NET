using CarFleet.Cargos.Entities;
using ExceptionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.Cargos.Factories
{
    public class ChemistryCargoCreator : CargoCreator
    {
        int id;
        double weight, volume;
        string type;
        double optimalStorageTemperature;
        bool isLiquid;

        public ChemistryCargoCreator(int id, double weight, double volume,
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
                case ConcreteCargo.Gas:
                    cargo = new Gas(id, weight, volume, optimalStorageTemperature, isLiquid);
                    break;
                case ConcreteCargo.Petrol:
                    cargo = new Petrol(id, weight, volume, optimalStorageTemperature, isLiquid);
                    break;
                case ConcreteCargo.Diesel:
                    cargo = new Diesel(id, weight, volume, optimalStorageTemperature, isLiquid);
                    break;
                default:
                    throw new ObjectExistenceException();
            }
            return cargo;
        }
    }
}
