using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Categories
{
    abstract public class TruckCategory : ITruckCategory
    {
        public int CategoryId { get; set; }

        public TruckCategory(int categoryId)
        {
            CategoryId = categoryId;
        }

        public abstract TruckCategories GetName();

        public override bool Equals(object obj)
        {
            return Equals(obj as TruckCategory);
        }

        public bool Equals(TruckCategory truckCategory)
        {
            var flag = false;
            if (truckCategory != null)
            {
                if (CategoryId == truckCategory.CategoryId &&
                    GetName() == truckCategory.GetName())
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
