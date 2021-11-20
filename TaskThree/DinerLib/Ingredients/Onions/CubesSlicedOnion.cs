using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients.Onions
{
    public class CubesSlicedOnion : SlicedOnion
    {
        public CubesSlicedOnion(double costPrice, DateTime createTime) : base(costPrice, createTime)
        { }

        public override SlicingTypes SlicingType => SlicingTypes.Cubes;
    }
}
