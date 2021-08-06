using DinerLib.Ingredients;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.DataAccess
{
    public interface IQueue<T>
        where T : class
    {
        List<T> ShowQueue();

        void DeleteFromQueue(T t);

        void AddToQueue(T t);

        T GetLastInQueue();
    }
}
