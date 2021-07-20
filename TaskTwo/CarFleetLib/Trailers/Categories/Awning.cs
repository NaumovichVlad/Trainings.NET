using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Categories
{
    public class Awning : TrailerCategory
    {
        public Awning(int id)
            : base(id)
        { }

        public override TrailerCategories GetName()
        {
            return TrailerCategories.Awning;
        }
    }
}
