using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients.Tomato
{
    public abstract class SlicedTomato : Tomato, ISlicedIngredient
    {
        public SlicedTomato(double costPrice, DateTime createTime) : base(costPrice, createTime)
        {
        }

        public override ProcessingTypes ProcessingType => ProcessingTypes.Slicing;
        public abstract SlicingTypes SlicingType { get; }
    }
}
