using DinerLib;
using DinerLib.FileManager.Recipes;
using DinerLib.Ingredients;
using DinerLib.Ingredients.Onions;
using DinerLib.Positions;
using DinerLib.Recipes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DinerLibTests
{
    [TestClass]
    public class KitchenTest
    {
        [TestMethod]
        public void Cook_TestOne()
        {
            var recipe = new Recipe(DishNames.SaladMoskow, new List<IngredientForRecipe>
            {
                new IngredientForRecipe(IngredientTypes.Onion, ProcessingTypes.Slicing, SlicingTypes.Cubes.ToString())
            });
            string connectionString = @"../../../Data/Recipes/recipes.json";
            var serializer = JsonSerializer.Create();
            
            var recipes = new List<IRecipe> { recipe };
            using (StreamWriter sw = File.CreateText(connectionString))
            {
                serializer.Serialize(sw, recipes);
            }
            var ingredients = new List<IIngredient>
            {
                new CubesSlicedOnion(10, DateTime.Now)
            };
            var expected = new SaladMoscow(ingredients, recipe);
            var actual = Kitchen.Cook(DishNames.SaladMoskow);
            Assert.AreEqual(expected, actual);
        }
    }
}
