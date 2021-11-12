using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Positions
{
    public interface IDish
    {
        List<IIngredient> Ingredients { get; set; }
        int CookingTime { get; }
        double CostPrice { get; }
        DishNames Name { get; }
    }
}
