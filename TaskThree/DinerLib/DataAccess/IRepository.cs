using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.DataAccess
{
    public interface IRepository<T>
        where T : class
    {
        void Create(T t);
        List<T> Read();
        void Update(T t);
        void Delete(T t);
    }
}
