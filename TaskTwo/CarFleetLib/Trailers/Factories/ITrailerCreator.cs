using CarFleetLib.Trailers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Factories
{
    public interface ITrailerCreator
    {
        ITrailer CreateTrailer(int id, double loadCapacity, double volume, double ownWeight, string category);
    }
}
