using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos
{
    public abstract class Materials : Cargo
    {
        public Materials (double weight, double volume)
            : base (weight, volume)
        { }

        public override CargoCategories GetCargoCategory()
        {
            return CargoCategories.Materials;
        }
    }
}
