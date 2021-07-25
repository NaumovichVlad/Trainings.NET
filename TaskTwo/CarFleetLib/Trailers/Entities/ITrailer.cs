using CarFleetLib.Cargos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Entities
{
    public interface ITrailer
    {
        int TrailerId { get; set; }
        double LoadСapacity { get; set; }
        double Volume { get; set; }
        double OwnWeight { get; }
        double CargoWeight { get; }
        double CargoVolume { get; }

        void LoadCargo(List<ICargo> cargos);
        List<ICargo> UnloadCargo();
        List<ICargo> ShowCargo();
        TrailerCategories GetTrailerType();
    }
}
