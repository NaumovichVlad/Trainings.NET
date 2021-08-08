using DinerLib.Ingredients;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.DataAccess
{
    /// <summary>
    /// Storage of information about ingredients in the queue
    /// </summary>
    public interface IQueue<T> : IEnumerable
        where T : IIngredient
    {
        int Count { get; }
        T this[int index] { get; set; }
        List<T> ToList();

        void DeleteFromQueue(T t);

        void AddToQueue(T t);

        T GetLastInQueue();

        void DeleteReadyMade();
    }
}
