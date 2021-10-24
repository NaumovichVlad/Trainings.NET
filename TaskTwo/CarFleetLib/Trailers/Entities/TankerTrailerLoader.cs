using CarFleetLib.Cargos.Entities;
using System.Collections.Generic;

namespace CarFleetLib.Trailers.Entities
{
    public  class TankerTrailerLoader : ILoader
    {
        public bool CheckAdditionalLoadingConditions(List<ICargo> cargos, List<ICargo> cargosForLoad)
        {
            foreach (var cargo in cargosForLoad)
            {
                if (!cargo.IsLiquid)
                    return false;
            }
            if (cargos != null)
            {
                foreach (var cargo in cargosForLoad)
                {
                    if (cargos[0].GetCargoType() != cargo.GetCargoType())
                        return false;
                }
            }
            return true;
        }
    }
}