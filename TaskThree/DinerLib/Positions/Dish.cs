using DinerLib.Ingredients;
using DinerLib.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Positions
{
    public abstract class Dish : IDish
    {
        private readonly Recipe _recipe;
        public List<IIngredient> Ingredients { get; set; }
        public int CookingTime => ComputeCookingTime();
        public double CostPrice => ComputeCostPrice();
        public abstract DishNames Name { get; }

        public Dish(List<IIngredient> ingredients, Recipe recipe)
        {
            Ingredients = ingredients;
            _recipe = recipe;
            CheckRecipe();
        }

        private int ComputeCookingTime()
        {
            var maxTime = Ingredients.Max(i => i.CreateTime);
            return (maxTime - DateTime.Now).Minutes;
        }

        private double ComputeCostPrice()
        {
            return Ingredients.Sum(i => i.CostPrice);
        }

        private void CheckRecipe()
        {
            if (Ingredients.Count == _recipe.Ingredients.Count)
            {
                for (var i = 0; i < Ingredients.Count; i++)
                    if (Ingredients[i].ProcessingType != _recipe.Ingredients[i].ProcessingType ||
                        Ingredients[i].Type != _recipe.Ingredients[i].IngredientType)
                        throw new Exception();
            }
        }
        public override bool Equals(object obj)
        {
            return obj is Dish dish &&
                   CookingTime == dish.CookingTime &&
                   CostPrice == dish.CostPrice &&
                   Name == dish.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = -57322951;
            hashCode = hashCode * -1521134295 + CookingTime.GetHashCode();
            hashCode = hashCode * -1521134295 + CostPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + Name.GetHashCode();
            return hashCode;
        }
    }
}
