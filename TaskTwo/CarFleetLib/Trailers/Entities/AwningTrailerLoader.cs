using CarFleetLib.Cargos.Entities;
using System.Collections.Generic;

namespace CarFleetLib.Trailers.Entities
{
    public class AwningTrailerLoader : Loader, ILoader
    {
        public override bool CheckAdditionalLoadingConditions(List<ICargo> cargos, List<ICargo> cargosForLoad)
        {
            foreach (var cargo in cargosForLoad)
            {
                if (cargo.IsLiquid == true)
                    return false;
            }
            return true;
        }
    }
}