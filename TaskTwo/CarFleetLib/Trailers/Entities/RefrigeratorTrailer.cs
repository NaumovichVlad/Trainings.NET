using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Entities
{
    public class RefrigeratorTrailer : Trailer, IFrozen
    {
        public double Temperature { get; set; }

        protected override ILoader Loader { get; }

        public RefrigeratorTrailer(int id, double loadCapacity, double volume, double ownWeight)
            : base(id, loadCapacity, volume, ownWeight)
        {
            Loader = new RefrigeratorTrailerLoader();
        }

        public override TrailerCategories GetTrailerType()
        {
            return TrailerCategories.Refrigerator;
        }
    }
}
