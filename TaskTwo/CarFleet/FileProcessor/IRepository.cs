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
        void Create(T t);
        List<T> Read();
    }
}
