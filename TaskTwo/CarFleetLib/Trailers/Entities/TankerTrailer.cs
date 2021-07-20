using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Entities
{
    abstract public class TankerTrailer : Trailer
    {
        public TankerTrailer (int id, double loadCapacity, double volume, double ownWeight)
            : base (id, loadCapacity, volume, ownWeight)
        { }

        public override TrailerCategories GetTrailerType()
        {
            return TrailerCategories.Tanker;
        }
    }
}
