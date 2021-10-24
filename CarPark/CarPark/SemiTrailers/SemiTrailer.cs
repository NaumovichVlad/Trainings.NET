using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.SemiTrailers
{
    /// <summary>
    /// class that describes the SemiTrailer
    /// </summary>
    public class SemiTrailer
    {
        /// <summary>
        /// type of semi-trailer
        /// </summary>
        public string Type;
        /// <summary>
        /// semitrailer carrying capacity
        /// </summary>
        public int LiftingCapacity;
        /// <summary>
        /// available volume of products
        /// </summary>
        public int AvailableVolume;
        /// <summary>
        /// available mass of products
        /// </summary>
        public int AvailableMass;
        /// <summary>
        /// type of loaded product
        /// </summary>
        public string UploadedProductType;
        /// <summary>
        /// the volume occupied by the product
        /// </summary>
        public int OccupiedVolume;
        /// <summary>
        /// the mass occupied by the product
        /// </summary>
        public int OccupiedWeight;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"> type of semi-trailer </param>
        /// <param name="liftingCapacity"> semitrailer carrying capacity </param>
        /// <param name="availableVolume"> available volume of products </param>
        /// <param name="availableMass"> available mass of products </param>
        /// <param name="uploadedProductType"> type of loaded product </param>
        /// <param name="occupiedVolume"> the volume occupied by the product </param>
        /// <param name="occupiedWeight"> the mass occupied by the product </param>
        public SemiTrailer(string type, int liftingCapacity, int availableVolume, int availableMass, string uploadedProductType, int occupiedVolume, int occupiedWeight)
        {
            Type = type;
            LiftingCapacity = liftingCapacity;
            AvailableVolume = availableVolume;
            AvailableMass = availableMass;
            UploadedProductType = uploadedProductType;
            OccupiedVolume = occupiedVolume;
            OccupiedWeight = occupiedWeight;
        }
        public SemiTrailer()
        {

        }

    }
}
