using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Dishes.Factories
{
    public interface IDishFactory
    {
        IMeal CreateMeal(DishTypes type);
    }
}
