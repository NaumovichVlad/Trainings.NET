using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Positions
{
    public class SaladMoscow : Dish
    {
        public SaladMoscow(List<IIngredient> ingredients) : base(ingredients)
        { }
        public override DishNames Name => DishNames.SaladMoskow;
    }
}
