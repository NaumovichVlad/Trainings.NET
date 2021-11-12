using DinerLib.Ingredients;
using DinerLib.Ingredients.Onions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors.Slicers
{
    internal class StripesSlicer : IConcreteSlicer
    {
        public ISlicedIngredient ProcessIngredient(IngredientTypes ingredientType, DateTime createTime)
        {
            ISlicedIngredient ingredient = null;
            switch (ingredientType)
            {
                case IngredientTypes.Onion:
                    ingredient = new StripesSlicedOnion(0, createTime);
                    break;
            }
            return ingredient;
        }
    }
}
