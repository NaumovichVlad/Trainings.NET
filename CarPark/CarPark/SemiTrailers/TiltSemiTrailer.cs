using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.SemiTrailers
{
    public class TiltSemiTrailer : SemiTrailer
    {
        public TiltSemiTrailer(string type, int liftingCapacity, int availableVolume, int availableMass, string uploadedProductType, int occupiedVolume, int occupiedWeight)
           : base(type, liftingCapacity, availableVolume, availableMass, uploadedProductType,  occupiedVolume, occupiedWeight)
        {
            Type = type;
            LiftingCapacity = liftingCapacity;
            AvailableVolume = availableVolume;
            AvailableMass = availableMass;
            UploadedProductType = uploadedProductType;
            OccupiedVolume = occupiedVolume;
            OccupiedWeight = occupiedWeight;
        }
    }
}
