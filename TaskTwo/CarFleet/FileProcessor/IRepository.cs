using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.FileProcessor
{
    public interface IRepository<T>
         where T : class
    {
        void Save(List<T> t);
        List<T> Load();
    }
}
