using System.Collections.Generic;

namespace DinerLib.Recipes
{
    public interface IRecipe
    {
        DishNames DishName { get; set; }
        List<IngredientForRecipe> Ingredients { get; set; }
    }
}