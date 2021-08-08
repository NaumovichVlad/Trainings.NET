using DinerLib.Ingredients;
using DinerLib.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionsLib;

namespace DinerLib.Dishes
{
    public abstract class Dish : IDish
    {
        
        List<IIngredient> ingredients;
        public int ProcessingTime { get { return CalculateProcessingTime(); } }
        public double CostPrice { get { return CalculateCostPrice(); } }
        public double MarkUp { get; set; }

        public IRecipe Recipe { get; set; }

        public Dish (double markUp, List<IIngredient> ingredients, IRecipe recipe)
        {
            MarkUp = markUp;
            this.ingredients = ingredients;
            Recipe = recipe;
            CheckRecipe();
        }

        private void CheckRecipe()
        {
            var recipe = Recipe.ShowRecipe();
            foreach (var position in recipe)
            {
                var count = ingredients.Where(i => i.ProcessingType == position.ProcessingType && 
                i.GetIngredientType() == position.IngredientType).Count();
                if (count != position.Count)
                    throw new NonComplianceWithRecipeException();
            }
        }
        
        public double CalculateCostPrice()
        {
            return ingredients.Sum(i => i.CostPrice);
        }

        public int CalculateProcessingTime()
        {
            TimeSpan[] time = new TimeSpan[ingredients.Count];
            for (int i = 0; i < ingredients.Count; i++) 
                time[i] = (ingredients[i].StartOfProcessingTime - DateTime.Now).Add(TimeSpan.FromMinutes(ingredients[i].ProcessingTime));
            return Convert.ToInt32(time.Max().Minutes);
        }
        public abstract DishTypes GetDishType();
    }
}
