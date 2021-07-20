using CarFleetLib.Trailers.Categories;
using ExceptionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Factories
{
    public class TrailerCategoryCreator : ITrailerCategoryCreator
    {
        public ITrailerCategory CreateCategory(string categoryName, int id)
        {
            TrailerCategories trailerCategory;
            ITrailerCategory categoryObject = null;
            if (!Enum.TryParse(categoryName, out trailerCategory))
                throw new ObjectExistenceException();
            switch (trailerCategory)
            {
                case TrailerCategories.Refrigerator:
                    categoryObject = new Refrigerator(id);
                    break;
                case TrailerCategories.Tanker:
                    categoryObject = new Tanker(id);
                    break;
                case TrailerCategories.Awning:
                    categoryObject = new Awning(id);
                    break;
                default:
                    throw new ObjectExistenceException();
            }
            return categoryObject;
        }
    }
}
