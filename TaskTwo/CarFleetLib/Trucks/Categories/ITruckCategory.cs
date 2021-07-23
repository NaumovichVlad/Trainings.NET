using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Categories
{
    public interface ITruckCategory
    {
        int CategoryId { get; set; }
        TruckCategories GetName();
    }
}
