using CarFleetLib.Cargos.Entities;
using CarFleetLib.FileProcessor;
using CarFleetLib.Trailers.Entities;
using CarFleetLib.Trucks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib
{
    /// <summary>
    /// Class for viewing the fleet
    /// </summary>
    public class Searcher : ISearcher
    {
        private List<ITrailer> trailers;
        private List<ITruck> trucks;

        public Searcher()
        {
            LoadData();
        }

        private void LoadData()
        {
            IRepository<ITrailer> trailerReader = new TrailersXml();
            trailers = trailerReader.Load();
            IRepository<ITruck> truckReader = new TrucksXml();
            trucks = truckReader.Load();

        }

        public List<ITrailer> ShowAllTrailers()
        {
            return trailers;
        }

        public List<ITruck> ShowAllTrucks()
        {
            return trucks;
        }

        public List<ITrailer> FindTrailersByParameters(TrailerCategories category, double loadCapacity, double volume)
        {
            var tmpTrailers = trailers.Where(t => t.GetTrailerType() == category);
            var suitableTrailers = tmpTrailers.Where(t => t.LoadСapacity >= loadCapacity && t.Volume >= volume).ToList();
            return suitableTrailers;
        }
    }
}
