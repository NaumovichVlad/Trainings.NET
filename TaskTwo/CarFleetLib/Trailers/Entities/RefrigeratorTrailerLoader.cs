using CarFleetLib.Cargos.Entities;
using System.Collections.Generic;

namespace CarFleetLib.Trailers.Entities
{
    public class RefrigeratorTrailerLoader : ILoader
    {
        public bool CheckAdditionalLoadingConditions(List<ICargo> cargos, List<ICargo> cargosForLoad)
        {
            var optimalStorageTemperature = cargosForLoad[0].OptimalStorageTemperature;
            foreach (var cargo in cargosForLoad)
            {
                if (cargo.IsLiquid == true || cargo.OptimalStorageTemperature != optimalStorageTemperature)
                    return false;
            }
            if (cargos != null)
            {
                if (cargos[0].OptimalStorageTemperature != optimalStorageTemperature)
                    return false;
            }
            return true;
        }
    }
}