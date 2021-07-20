using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Categories
{
    public interface ITrailerCategory
    {
        int CategoryId { get; set; }
        TrailerCategories GetName();
    }
}
