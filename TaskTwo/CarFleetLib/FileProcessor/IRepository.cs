using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.FileProcessor
{
    public interface IRepository<T>
         where T : class
    {
        void Save(List<T> t);
        List<T> Load();
    }
}
