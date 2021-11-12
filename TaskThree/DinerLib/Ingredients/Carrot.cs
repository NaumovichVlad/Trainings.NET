using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public abstract class Carrot : Ingredient
    {
        protected Carrot(double costPrice, DateTime createTime) : base(costPrice, createTime)
        { }

        public override IngredientTypes Type { get => IngredientTypes.Carrot; }
    }
}
