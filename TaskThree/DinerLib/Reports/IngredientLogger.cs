using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Reports
{
    public class IngredientLogger : Logger<Ingredient>
    {
        public IngredientLogger()
        {
            connectionString = @"../../../Data/Log/ingredients.json";
        }
    }
}
