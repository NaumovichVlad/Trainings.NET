using DinerLib.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib
{
    public interface IDiner
    {
        List<IDish> PrepareAnOrder(List<DishTypes> positions);
    }
}
