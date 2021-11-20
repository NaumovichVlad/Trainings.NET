using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Recipes
{
    public class Recipe : IRecipe
    {
        public DishNames DishName { get; set; }
        public List<IngredientForRecipe> Ingredients { get; set; }

        public Recipe(DishNames dishNames, List<IngredientForRecipe> ingredientsForRecipes)
        {
            DishName = dishNames;
            Ingredients = ingredientsForRecipes;
        }

        public override bool Equals(object obj)
        {
            if (obj is Recipe recipe &&
                   DishName == recipe.DishName)
            {
                if (recipe.Ingredients.Count == Ingredients.Count)
                {
                    for (var i = 0; i < Ingredients.Count; i++)
                        if(!recipe.Ingredients[i].Equals(Ingredients[i]))
                            return false;
                    return true;
                }
            }
            return false;
                   
        }

        public override int GetHashCode()
        {
            int hashCode = 757171637;
            hashCode = hashCode * -1521134295 + DishName.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<IngredientForRecipe>>.Default.GetHashCode(Ingredients);
            return hashCode;
        }
    }
}
