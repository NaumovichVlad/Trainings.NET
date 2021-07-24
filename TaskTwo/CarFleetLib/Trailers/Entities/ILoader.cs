using CarFleetLib.Cargos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Entities
{
    public interface ILoader
    {
        bool CheckAdditionalLoadingConditions(List<ICargo> cargos, List<ICargo> cargosForLoad);
    }
}
