using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients.Carrot
{
    public class StripesSlicedCarrot : SlicedCarrot
    {
        public StripesSlicedCarrot(double costPrice, DateTime createTime) : base(costPrice, createTime)
        {
        }

        public override SlicingTypes SlicingType => SlicingTypes.Stripes;
    }
}
