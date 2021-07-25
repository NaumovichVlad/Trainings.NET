using CarFleetLib.Cargos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Entities
{
    /// <summary>
    /// Class for checking additional loading conditions
    /// </summary>
    public interface ILoader
    {
        bool CheckAdditionalLoadingConditions(List<ICargo> cargos, List<ICargo> cargosForLoad);
    }
}
