using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients.Onions
{
    public class StripesSlicedOnion : SlicedOnion
    {
        public StripesSlicedOnion(double costPrice) : base(costPrice)
        { }

        public override SlicingTypes SlicingType => SlicingTypes.Stripes;
    }
}
