using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.Cargos.Categories
{
    abstract public class CargoCategory : ICargoCategory
    {
        public int CategoryId { get; set; }

        public CargoCategory (int id)
        {
            CategoryId = id;
        }

        abstract public CargoCategories GetName();

        public override bool Equals(object obj)
        {
            return Equals(obj as CargoCategory);
        }

        public bool Equals(CargoCategory cargoType)
        {
            var flag = false;
            if (cargoType != null)
            {
                if (CategoryId == cargoType.CategoryId && 
                    GetName() == cargoType.GetName())
                {
                    flag = true;
                }
            }
            return flag;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CategoryId, GetName());
        }
    }
}
