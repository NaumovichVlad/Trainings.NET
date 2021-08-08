using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public abstract class Onion : Ingredient, IOnion
    {
        public Onion (ProcessingTypes processingType, int processingTime, DateTime startOfProcessingTime, double costPrice)
            : base(processingType, processingTime, startOfProcessingTime, costPrice)
        { }

        public new IngredientTypes GetIngredientType()
        {
            return IngredientTypes.Onion;
        }
    }
}
