using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Categories
{
    public class Tractor : TruckCategory
    {
        public Tractor (int id)
            : base (id)
        { }
        public override TruckCategories GetName()
        {
            return TruckCategories.TruckTractor;
        }
    }
}
