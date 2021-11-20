using DinerLib.Recipes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.FileManager.Recipes
{
    /// <summary>
    /// class for uploading recipes
    /// </summary>
    public class RecipesJson
    {
        private const string _connectionString = @"../../../Data/Recipes/recipes.json";
        /// <summary>
        /// Load recipes
        /// </summary>
        /// <returns>recipes</returns>
        public List<Recipe> LoadRecipes()
        {
            var recipes = new List<Recipe>();
            using (StreamReader sr = new StreamReader(_connectionString))
            {
                var serializer = JsonSerializer.Create();
                JsonReader jr = new JsonTextReader(sr);
                recipes = serializer.Deserialize<List<Recipe>>(jr);
            }
            return recipes;
        }

        /// <summary>
        /// Add new recipe in file
        /// </summary>
        /// <param name="recipe">New recipe</param>
        public void AddRecipe(Recipe recipe)
        {
            var recipes = new List<Recipe>();
            var serializer = JsonSerializer.Create();
            using (StreamReader sr = new StreamReader(_connectionString))
            {
                JsonReader jr = new JsonTextReader(sr);
                recipes = serializer.Deserialize<List<Recipe>>(jr);
            }
            recipes.Add(recipe);
            using (StreamWriter sw = File.CreateText(_connectionString))
            {
                serializer.Serialize(sw, recipes);
            }
        }
    }
}
