using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients.Onions
{
    public abstract class Onion : Ingredient
    {
        protected Onion(double costPrice, DateTime createTime) : base(costPrice, createTime)
        { }

        public override IngredientTypes Type => IngredientTypes.Onion;
    }
}
