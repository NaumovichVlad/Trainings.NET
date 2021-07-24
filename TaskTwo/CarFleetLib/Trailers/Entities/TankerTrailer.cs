using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Entities
{
    public class TankerTrailer : Trailer
    {
        protected override ILoader Loader { get; }
        public TankerTrailer (int id, double loadCapacity, double volume, double ownWeight)
            : base (id, loadCapacity, volume, ownWeight)
        {
            Loader = new TankerTrailerLoader();
        }

        public override TrailerCategories GetTrailerType()
        {
            return TrailerCategories.Tanker;
        }
    }
}
