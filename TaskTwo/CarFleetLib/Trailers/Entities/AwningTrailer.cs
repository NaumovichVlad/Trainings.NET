using CarFleetLib.Cargos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Entities
{
    public class AwningTrailer : Trailer
    {
        protected override ILoader Loader { get ;}
        public AwningTrailer(int id, double loadCapacity, double volume, double ownWeight)
            : base(id, loadCapacity, volume, ownWeight)
        { 
            Loader = new AwningTrailerLoader();
        }

        public override TrailerCategories GetTrailerType()
        {
            return TrailerCategories.Awning;
        }
    }
}
