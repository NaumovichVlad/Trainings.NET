using CarFleetLib.Cargos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionsLib;

namespace CarFleetLib.Trailers.Entities
{
    abstract public class Trailer : ITrailer
    {
        private List<ICargo> cargos = null;
        public int TrailerId { get; set; }
        public double LoadСapacity { get; set; }
        public double Volume { get; set; }
        public double OwnWeight { get; }
        public double CargoWeight => CalculateTotalCargoWeight();
        public double CargoVolume => CalculateTotalCargoVolume();

        public Trailer(int id, double loadCapacity, double volume, double ownWeight)
        {
            TrailerId = id;
            LoadСapacity = loadCapacity;
            Volume = volume;
            OwnWeight = ownWeight;
        }

        public void LoadCargo(List<ICargo> cargosForLoad)
        {
            var weight = CalculateTotalCargoWeight();
            weight += cargosForLoad.Sum(c => c.Weight);
            var volume = CalculateTotalCargoVolume();
            volume += cargos.Sum(c => c.Volume);
            if (weight <= LoadСapacity && volume <= Volume)
            {
                cargos = cargos.Concat(cargosForLoad).ToList();
            }
            else
                throw new TrailerOverflowException();
        }

        private double CalculateTotalCargoWeight()
        {
            double weight = 0;
            if (cargos != null)
                weight = cargos.Sum(c => c.Weight);
            return weight;
        }

        private double CalculateTotalCargoVolume()
        {
            double volume = 0;
            if (cargos != null)
                volume = cargos.Sum(c => c.Volume);
            return volume;
        }

        public List<ICargo> UnloadCargo()
        {
            var unloadedCargo = cargos;
            cargos = null;
            return unloadedCargo;
        }

        abstract public TrailerCategories GetTrailerType();
    }
}
