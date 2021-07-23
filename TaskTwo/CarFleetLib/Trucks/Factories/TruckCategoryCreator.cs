using CarFleetLib.Trucks.Categories;
using ExceptionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Factories
{
    public class TruckCategoryCreator : ITruckCategoryCreator
    {
        public ITruckCategory CreateCategory(string categoryName, int id)
        {
            TruckCategories trailerCategory;
            ITruckCategory categoryObject = null;
            if (!Enum.TryParse(categoryName, out trailerCategory))
                throw new ObjectExistenceException();
            switch (trailerCategory)
            {
                case TruckCategories.TruckTractor:
                    categoryObject = new Tractor(id);
                    break;
                default:
                    throw new ObjectExistenceException();
            }
            return categoryObject;
        }
    }
}
