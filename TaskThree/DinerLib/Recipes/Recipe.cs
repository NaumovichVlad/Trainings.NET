using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Recipes
{
    public class Recipe : IRecipe
    {
        List<IngredientForRecipe> ingredients;
        public Recipe(List<IngredientForRecipe> ingredients)
        {
            this.ingredients = ingredients;
        }
        public void ChangeRecipe(List<IngredientForRecipe> ingredients)
        {
            this.ingredients = ingredients;
        }

        public List<IngredientForRecipe> ShowRecipe()
        {
            return ingredients;
        }
    }
}
