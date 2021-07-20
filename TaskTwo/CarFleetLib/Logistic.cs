using CarFleetLib.Cargos.Entities;
using CarFleetLib.FileProcessor;
using CarFleetLib.Trailers.Entities;
using CarFleetLib.Trucks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib
{
    public class Logistic
    {
        private List<ICargo> cargos;
        private List<ITrailer> trailers;
        private List<ITruck> trucks;

        public Logistic()
        {
            LoadData();
        }

        private void LoadData()
        {
            IRepository<ICargo> cargoReader = new CargosXml();
            cargos = cargoReader.Load();
            // И так далее...
        }

        public void SaveData()
        {
            IRepository<ICargo> cargoReader = new CargosXml();
            cargoReader.Save(cargos);
            // И так далее...
        }
    }
}
