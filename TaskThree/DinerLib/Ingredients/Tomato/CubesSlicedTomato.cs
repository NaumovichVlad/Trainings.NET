using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients.Tomato
{
    public class CubesSlicedTomato : SlicedTomato
    {
        public CubesSlicedTomato(double costPrice, DateTime createTime) : base(costPrice, createTime)
        {
        }

        public override SlicingTypes SlicingType => SlicingTypes.Cubes;
    }
}
