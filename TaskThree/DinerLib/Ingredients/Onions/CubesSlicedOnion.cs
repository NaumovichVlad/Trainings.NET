using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients.Onions
{
    internal class CubesSlicedOnion : SlicedOnion
    {
        public CubesSlicedOnion(double costPrice) : base(costPrice)
        { }

        public override SlicingTypes SlicingType => SlicingTypes.Cubes;
    }
}
