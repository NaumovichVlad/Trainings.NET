using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Recipes
{
    public class Recipe
    {
        public DishNames DishName { get; set; }
        public List<IngredientForRecipe> Ingredients { get; set; }

        public Recipe (DishNames dishNames, List<IngredientForRecipe> ingredientsForRecipes)
        {
            DishName = dishNames;
            Ingredients = ingredientsForRecipes;
        }
    }
}
