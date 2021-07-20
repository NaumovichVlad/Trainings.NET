using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Categories
{
    public class Refrigerator : TrailerCategory
    {
        public Refrigerator (int id)
            : base (id)
        { }

        public override TrailerCategories GetName()
        {
            return TrailerCategories.Refrigerator;
        }
    }
}
