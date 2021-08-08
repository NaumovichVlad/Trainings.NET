using DinerLib.Dishes;
using DinerLib.Dishes.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib
{
    public class Diner : IDiner
    {
        public List<IDish> PrepareAnOrder(List<DishTypes> positions)
        {
            IDishFactory dishFactory = new DishFactory();
            List<IDish> dishes = new List<IDish>();
            foreach (DishTypes dishType in positions)
                dishes.Add(dishFactory.CreateMeal(dishType));
            return dishes;
        }
    }
}
