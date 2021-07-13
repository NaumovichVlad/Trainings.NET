using CarFleet.Cargos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.Cargos.Factories
{
    abstract public class CargoCreator : ICargoCreator
    {
        abstract public ICargo CreateCargo();
    }
}
