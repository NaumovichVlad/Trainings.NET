using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Recipes
{
    public interface IRecipe
    {
        List<IngredientForRecipe> ShowRecipe();
        void ChangeRecipe(List<IngredientForRecipe> ingredients);
    }
}
