using CarFleetLib.Cargos.Entities;
using CarFleetLib.Cargos.Factories;
using CarFleetLib.Trailers.Entities;
using ExceptionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Factories
{
    /// <summary>
    /// Factory for creating trailers
    /// </summary>
    public class TrailerCreator : ITrailerCreator
    {
        public ITrailer CreateTrailer(int id, double loadCapacity, double volume, double ownWeight, string category)
        {
            TrailerCategories trailerCategory;
            ITrailer trailer = null;
            if (!Enum.TryParse(category, out trailerCategory))
                throw new ObjectExistenceException();
            switch (trailerCategory)
            {
                case TrailerCategories.Awning:
                    trailer = new AwningTrailer(id, loadCapacity, volume, ownWeight);
                    break;
                case TrailerCategories.Refrigerator:
                    trailer = new RefrigeratorTrailer(id, loadCapacity, volume, ownWeight);
                    break;
                case TrailerCategories.Tanker:
                    trailer = new TankerTrailer(id, loadCapacity, volume, ownWeight);
                    break;
            }
            return trailer;
        }
    }
}
