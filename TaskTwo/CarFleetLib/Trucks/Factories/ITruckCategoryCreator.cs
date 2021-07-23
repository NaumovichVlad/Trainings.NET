using CarFleetLib.Trucks.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Factories
{
    public interface ITruckCategoryCreator
    {
        ITruckCategory CreateCategory(string categoryName, int id);
    }
}
