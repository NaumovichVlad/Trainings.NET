using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.SemiTrailers
{
    public class SemiTrailerCreator
    {
        SemiTrailer semiTrailer = new SemiTrailer();
        public SemiTrailer CreateST(string type, int liftingCapacity, int availableVolume, int availableMass, string uploadedProductType, int occupiedVolume, int occupiedWeight)
        {          
            switch(type)
            {
                case "AutoTank":
                    semiTrailer = new AutoTank(type, liftingCapacity, availableVolume, availableMass, uploadedProductType, occupiedVolume, occupiedWeight);
                    break;
                case "Refrigerator":
                    semiTrailer = new Refrigerator(type, liftingCapacity, availableVolume, availableMass, uploadedProductType, occupiedVolume, occupiedWeight);
                    break;
                case "TiltSemiTrailer":
                    semiTrailer = new TiltSemiTrailer(type, liftingCapacity, availableVolume, availableMass, uploadedProductType, occupiedVolume, occupiedWeight);
                    break;
            }
            return semiTrailer;
        }
    }
}
