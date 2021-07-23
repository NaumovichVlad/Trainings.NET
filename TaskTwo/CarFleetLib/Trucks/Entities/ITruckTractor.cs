using CarFleetLib.Trailers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trucks.Entities
{
    interface ITruckTractor : ITruck
    {
        void AttachTrailer(ITrailer trailer);
        ITrailer UnhookTrailer();
    }
}
