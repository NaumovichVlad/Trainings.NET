using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.Cargos
{
    abstract public class Products : Cargo
    {
        public Products(double weight, double volume)
                : base(weight, volume)
        { }

        public override CargoCategories GetCargoCategory()
        {
            return CargoCategories.Products;
        }
    }
}
