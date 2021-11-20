using DinerLib.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Reports
{
    public class DishesLogger : Logger<Dish>
    {
        public DishesLogger()
        {
            connectionString = @"../../../Data/Log/dishes.json";
        }
    }
}
