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
        protected abstract ILoader Loader { get;}
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
            if (weight <= LoadСapacity && volume <= Volume && 
                Loader.CheckAdditionalLoadingConditions(cargos, cargosForLoad))
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

        public List<ICargo> ShowCargo()
        {
            return cargos;
        }

        abstract public TrailerCategories GetTrailerType();

        public override bool Equals(object obj)
        {
            return Equals(obj as Trailer);
        }

        public bool Equals(Trailer trailer)
        {
            var flag = false;
            if (trailer != null)
            {
                if (trailer.TrailerId == TrailerId &&
                    trailer.LoadСapacity == LoadСapacity &&
                    trailer.Volume == Volume &&
                    trailer.OwnWeight == OwnWeight &&
                    trailer.GetTrailerType() == GetTrailerType())
                {
                    flag = true;
                }
            }
            return flag;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LoadСapacity, Volume, GetTrailerType(), OwnWeight, TrailerId);
        }
    }
}
