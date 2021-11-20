using DinerLib.Ingredients;
using DinerLib.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Positions
{
    public class SaladMoscow : Dish
    {
        public SaladMoscow(List<IIngredient> ingredients, IRecipe recipe) : base(ingredients, recipe)
        { }
        public override DishNames Name => DishNames.SaladMoskow;
    }
}
