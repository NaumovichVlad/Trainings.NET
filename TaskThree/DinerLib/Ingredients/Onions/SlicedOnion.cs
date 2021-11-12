using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients.Onions
{
    public abstract class SlicedOnion : Onion, ISlicedIngredient
    {
        protected SlicedOnion(double costPrice) : base(costPrice)
        { }

        public override ProcessingTypes ProcessingType => ProcessingTypes.Slicing;
        public abstract SlicingTypes SlicingType { get; }
    }
}
