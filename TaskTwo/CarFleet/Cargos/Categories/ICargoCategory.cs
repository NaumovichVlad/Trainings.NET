using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.Cargos.Categories
{
    public interface ICargoCategory
    {
        int CategoryId { get; set; }
        CargoCategories GetName();
    }
}
