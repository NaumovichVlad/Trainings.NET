using CarFleetLib.Cargos.Entities;
using CarFleetLib.Trailers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Entities
{
    public interface ITruck
    {
        int TruckId { get; set; }
        int TrailerId { get; set; }
        string TruckBrand { get; set; }
        string RegisterNumber { get; set; }
        double LoadCapacity {  get; set;}
        double FuelConsumption { get; set; }
        double FuelConsumptionPerTonOfCargo {  get; set; }

        double GetFuelConsumptionWithCargo();
        List<ICargo> UnloadCargo();
        List<ICargo> ShowCargo();
        void AttachTrailer(ITrailer trailer);
        ITrailer UnhookTrailer();
        void LoadCargo(List<ICargo> cargoList);
        TruckCategories GetTruckCategory();
    }
}
