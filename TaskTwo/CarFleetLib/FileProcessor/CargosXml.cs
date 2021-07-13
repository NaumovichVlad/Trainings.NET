using CarFleetLib.Cargos;
using CarFleetLib.Cargos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.FileProcessor
{
    public class CargosXml : Connection, IRepository<ICargo>
    {
        public List<ICargo> Load()
        {
            throw new NotImplementedException();
        }

        public void Save(List<ICargo> t)
        {
            throw new NotImplementedException();
        }
    }
}
