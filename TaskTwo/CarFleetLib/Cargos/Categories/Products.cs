using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos.Categories
{
    public class Products : CargoCategory, ICargoCategory
    {
        public Products(int id)
            : base(id)
        { }

        public override CargoCategories GetName()
        {
            return CargoCategories.Products;
        }
    }
}
