using DinerLib.Ingredients;
using DinerLib.Processors;
using DinerLib.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Dishes.Factories
{
    public class SaladFactory : ISaladFactory
    {
        public ISalad CreateSalad()
        {
            var ingredients = new List<IngredientForRecipe>
            {
                new IngredientForRecipe(IngredientTypes.Onion, ProcessingTypes.FineSlicing, 1),
                new IngredientForRecipe(IngredientTypes.Carrot, ProcessingTypes.FineSlicing, 1)
            };
            var recipe = new Recipe(ingredients);
            var finelySlicer = new FinelySlicer();
            var carrot = finelySlicer.ProcessCarrot(10, 10);
            var onion = finelySlicer.ProcessOnion(10, 5);
            var ingredientList = new List<IIngredient> { carrot, onion };
            return new Salad(10, ingredientList, recipe);
        }
    }
}
