using ExceptionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Dishes.Factories
{
    public class DishFactory : IDishFactory
    {
        public IMeal CreateMeal(DishTypes type)
        {
            IMeal dish = null;
            switch (type)
            {
                case DishTypes.Salad:
                    var dishCreator = new SaladFactory();
                    dish = dishCreator.CreateSalad();
                    break;
                default:
                    throw new DishException();
            }
            return dish;
        }
    }
}
