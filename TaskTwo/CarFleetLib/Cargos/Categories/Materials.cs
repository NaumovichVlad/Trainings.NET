using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos.Categories
{
    public class Materials : CargoCategory, ICargoCategory
    {
        public Materials (int id)
            : base(id)
        { }

        public override CargoCategories GetName()
        {
            return CargoCategories.Materials;
        }
    }
}
