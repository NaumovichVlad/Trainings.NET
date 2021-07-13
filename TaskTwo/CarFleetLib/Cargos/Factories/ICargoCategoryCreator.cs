using CarFleetLib.Cargos.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos.Factories
{
    public interface ICargoCategoryCreator
    {
        ICargoCategory CreateCategory(string category, int id);
    }
}
