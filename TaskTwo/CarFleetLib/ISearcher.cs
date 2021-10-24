using CarFleetLib.Trailers.Entities;
using CarFleetLib.Trucks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib
{
    public interface ISearcher
    {
        List<ITrailer> ShowAllTrailers();
        List<ITruck> ShowAllTrucks();
        List<ITrailer> FindTrailersByParameters(TrailerCategories category, double loadCapacity, double volume);
    }
}
