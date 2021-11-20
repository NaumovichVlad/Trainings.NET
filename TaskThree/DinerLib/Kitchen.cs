using DinerLib.FileManager.Recipes;
using DinerLib.Ingredients;
using DinerLib.Positions;
using DinerLib.Processors;
using DinerLib.Recipes;
using DinerLib.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib
{
    public static class Kitchen
    {
        
        public static IDish Cook(DishNames dishName)
        {
            var fileManager = new RecipesJson();
            var recipe = fileManager.LoadRecipes().Find(r => r.DishName == dishName);
            var ingredients = new List<IIngredient>();
            IIngredientProcessor ingredientProcessor = new IngredientProcessor();
            foreach (var ingredientForRicipe in recipe.Ingredients)
                ingredients.Add(ingredientProcessor.ProcessIngredient(ingredientForRicipe.IngredientType.ToString(),
                    ingredientForRicipe.ProcessingType.ToString(), ingredientForRicipe.ConcreteProcessingType));
            return CreateDish(dishName, ingredients, recipe);
        }

        private static IDish CreateDish(DishNames dishName, List<IIngredient> ingredients, IRecipe recipe)
        {
            var logger = new DishesLogger();
            Dish dish = null;
            switch (dishName)
            {
                case DishNames.SaladMoskow:
                    dish = new SaladMoscow(ingredients, recipe);
                    break;
            }
            logger.AddNote(dish);
            return dish;
        }
        
    }
}
