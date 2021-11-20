using DinerLib;
using DinerLib.FileManager.Recipes;
using DinerLib.Recipes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DinerLibTests.FileManager.Recipes
{
    [TestClass]
    public class RecipesJsonTests
    {
        [TestMethod]
        public void LoadRecipe_TestOne()
        {
            string connectionString = @"../../../Data/Recipes/recipes.json";
            IRecipe recipe = new Recipe(DishNames.SaladMoskow, new List<IngredientForRecipe>
            {
                new IngredientForRecipe(IngredientTypes.Carrot, ProcessingTypes.Slicing, SlicingTypes.Cubes.ToString()),
                new IngredientForRecipe(IngredientTypes.Onion, ProcessingTypes.Slicing, SlicingTypes.Stripes.ToString())
            });
            var expected = new List<IRecipe> { recipe };
            var serializer = JsonSerializer.Create();
            using (StreamWriter sw = File.CreateText(connectionString))
            {
                serializer.Serialize(sw, expected);
            }
            var fileManager = new RecipesJson();
            var actual = fileManager.LoadRecipes();
            for (var i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod] 
        public void AddRecipe_TestOne()
        {
            string connectionString = @"../../../Data/Recipes/recipes.json";
            var serializer = JsonSerializer.Create();
            Recipe recipe = new Recipe(DishNames.SaladMoskow, new List<IngredientForRecipe>
            {
                new IngredientForRecipe(IngredientTypes.Carrot, ProcessingTypes.Slicing, SlicingTypes.Cubes.ToString()),
                new IngredientForRecipe(IngredientTypes.Onion, ProcessingTypes.Slicing, SlicingTypes.Stripes.ToString())
            });
            var expected = new List<IRecipe> { recipe };
            using (StreamWriter sw = File.CreateText(connectionString))
            {
                serializer.Serialize(sw, expected);
            }
            expected.Add(recipe);
            var fileManager = new RecipesJson();
            fileManager.AddRecipe(recipe);
            var actual = new List<Recipe>();
            using (StreamReader sr = new StreamReader(connectionString))
            {
                JsonReader jr = new JsonTextReader(sr);
                actual = serializer.Deserialize<List<Recipe>>(jr);
            }
            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

    }
}
