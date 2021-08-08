using DinerLib.Ingredients;
using DinerLib.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Dishes
{
    public class Salad : Meal, ISalad
    {
        public Salad(double markUp, List<IIngredient> ingredients, IRecipe recipe)
            : base(markUp, ingredients, recipe)
        { }
        public override DishTypes GetDishType()
        {
            return DishTypes.Salad;
        }
    }
}
