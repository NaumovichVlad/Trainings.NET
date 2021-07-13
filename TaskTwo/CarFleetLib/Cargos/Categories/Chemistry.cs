using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos.Categories
{
    public class Chemistry : CargoCategory, ICargoCategory
    {
        public Chemistry(int id)
            : base(id)
        { }

        public override CargoCategories GetName()
        {
            return CargoCategories.Chemistry;
        }
    }
}
