using CarFleet.Cargos;
using CarFleet.Cargos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.FileProcessor
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
