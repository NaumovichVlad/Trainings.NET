using CarFleet.Cargos.Entities;
using ExceptionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.Cargos.Factories
{
    public class MaterialsCargoCreator : CargoCreator
    {
        int id;
        double weight, volume;
        string type;
        double optimalStorageTemperature;
        bool isLiquid;

        public MaterialsCargoCreator(int id, double weight, double volume,
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
                case ConcreteCargo.Brick:
                    cargo = new Brick(id, weight, volume, isLiquid);
                    break;
                case ConcreteCargo.Board:
                    cargo = new Board(id, weight, volume, optimalStorageTemperature, isLiquid);
                    break;
                case ConcreteCargo.Glass:
                    cargo = new Glass(id, weight, volume, optimalStorageTemperature, isLiquid);
                    break;
                default:
                    throw new ObjectExistenceException();
            }
            return cargo;
        }
    }
}
