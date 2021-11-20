using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients.Carrot
{
    public abstract class SlicedCarrot : Carrot, ISlicedIngredient
    {
        protected SlicedCarrot(double costPrice, DateTime createTime) : base(costPrice, createTime)
        {
        }

        public override ProcessingTypes ProcessingType => ProcessingTypes.Slicing;
        public abstract SlicingTypes SlicingType { get; }
    }
}
