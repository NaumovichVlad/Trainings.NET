using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Categories
{
    abstract public class TrailerCategory : ITrailerCategory
    {
        public int CategoryId { get; set; }

        public TrailerCategory (int id)
        {
            CategoryId = id;
        }

        abstract public TrailerCategories GetName();

        public override bool Equals(object obj)
        {
            return Equals(obj as TrailerCategory);
        }

        public bool Equals(TrailerCategory cargoType)
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
