using DinerLib.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Dishes
{
    public interface IDish
    {
        int ProcessingTime { get; }
        double CostPrice { get; }
        double MarkUp { get; set; }
        IRecipe Recipe { get; set; }

        DishTypes GetDishType();
    }
}
