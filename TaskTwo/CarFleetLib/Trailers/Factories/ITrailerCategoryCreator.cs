using CarFleetLib.Trailers.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Factories
{
    public interface ITrailerCategoryCreator
    {
        ITrailerCategory CreateCategory(string categoryName, int id);
    }
}
