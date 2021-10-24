using CarFleetLib.Trailers.Entities;
using System;
using ExceptionsLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleetLib.Cargos.Entities;

namespace CarFleetLib.Trucks.Entities
{
    public class TruckTractor : Truck
    {
        private ITrailer trailer;

        public TruckTractor(int truckId, string truckBrand, string registerNumber,
            double loadCapacity, double fuelConsumption, double fuelConsumptionPerTonOfCargo)
            : base(truckId, truckBrand, registerNumber, loadCapacity, fuelConsumption, fuelConsumptionPerTonOfCargo)
        { }
        public TruckTractor(int truckId, string truckBrand, string registerNumber,
            double loadCapacity, double fuelConsumption, 
            double fuelConsumptionPerTonOfCargo, ITrailer trailer)
            : base(truckId, truckBrand, registerNumber, loadCapacity, fuelConsumption, fuelConsumptionPerTonOfCargo)
        { 
            this.trailer = trailer;
        }

        public override double GetFuelConsumptionWithCargo()
        {
            double fuelConsumption;
            if (trailer != null)
            {
                var trailerWeight = trailer.CargoWeight + trailer.OwnWeight;
                fuelConsumption = FuelConsumption + FuelConsumptionPerTonOfCargo * trailerWeight;
            }
            else
            {
                fuelConsumption = FuelConsumption;
            }
            return fuelConsumption;
        }

        public override void AttachTrailer(ITrailer trailer)
        {
            if (this.trailer == null && trailer != null)
            {
                this.trailer = trailer;
                TrailerId = trailer.TrailerId;
            }
            else
            {
                throw new TrailerExistenceExeption("The trailer is already attached");
            }
        }

        public override ITrailer UnhookTrailer()
        {
            ITrailer unhookedTrailer = null;
            if (trailer != null)
            {
                unhookedTrailer = trailer;
                trailer = null;
            }
            else
                throw new TrailerExistenceExeption("The trailer is not attached");
            return unhookedTrailer;
        }

        public override TruckCategories GetTruckCategory()
        {
            return TruckCategories.TruckTractor;
        }

        public override List<ICargo> UnloadCargo()
        {
            var cargos = new List<ICargo>();
            if (trailer != null)
            {
                cargos = trailer.UnloadCargo();
            }
            else
                throw new TrailerExistenceExeption("The trailer is not attached");
            return cargos;
        }

        public override void LoadCargo(List<ICargo> cargoList)
        {
            if (trailer != null)
            {
                trailer.LoadCargo(cargoList);
            }
            else
                throw new TrailerExistenceExeption("The trailer is not attached");
        }

        public override List<ICargo> ShowCargo()
        {
            var cargos = new List<ICargo>();
            if (trailer != null)
            {
                cargos = trailer.ShowCargo();
            }
            else
                throw new TrailerExistenceExeption("The trailer is not attached");
            return cargos;
        }
    }
}
