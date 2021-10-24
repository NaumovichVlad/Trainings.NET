using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public class Carrot : Ingredient
    {
        public Carrot(double costPrice) 
            : base(costPrice)
        { }

        public override IngredientTypes Type { get => IngredientTypes.Carrot; }
        public override ProcessingTypes ProcessingType { get => ProcessingTypes.None; }
    }
}
