using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients.Carrot
{
    internal class CubesSlicedCarrot : SlicedCarrot
    {
        public CubesSlicedCarrot(double costPrice, DateTime createTime) : base(costPrice, createTime)
        {
        }

        public override SlicingTypes SlicingType => SlicingTypes.Cubes;
    }
}
