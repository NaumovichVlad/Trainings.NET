using CarFleetLib.Cargos.Categories;
using ExceptionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos.Factories
{
    public class CargoCategoryCreator : ICargoCategoryCreator
    {
        public ICargoCategory CreateCategory(string category, int id)
        {
            CargoCategories cargoCategory;
            ICargoCategory categoryObject = null;
            if (!Enum.TryParse(category, out cargoCategory))
                throw new ObjectExistenceException();
            switch (cargoCategory)
            {
                case CargoCategories.Products:
                    categoryObject = new Products(id);
                    break;
                case CargoCategories.Chemistry:
                    categoryObject = new Chemistry(id);
                    break;
                case CargoCategories.Materials:
                    categoryObject = new Materials(id);
                    break;
                default:
                    throw new ObjectExistenceException();
            }
            return categoryObject;
        }
    }
}
