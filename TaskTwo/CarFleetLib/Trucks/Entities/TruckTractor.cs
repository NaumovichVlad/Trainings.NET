using CarFleetLib.Trailers.Entities;
using System;
using ExceptionsLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Entities
{
    public class TruckTractor : Truck, ITruckTractor
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

        public void AttachTrailer(ITrailer trailer)
        {
            if (this.trailer == null)
            {
                this.trailer = trailer;
            }
            else
            {
                throw new TrailerExistenceExeption("The trailer is already attached");
            }
        }

        public ITrailer UnhookTrailer()
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
    }
}
