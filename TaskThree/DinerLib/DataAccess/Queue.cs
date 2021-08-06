using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.DataAccess
{
    public class Queue<T> : IQueue<T>
        where T : class
    {
        private List<T> _queue;

        public Queue (List<T> queueList)
        {
            _queue = queueList;
        }

        public List<T> ShowQueue()
        {
            return _queue;
        }

        public void DeleteFromQueue(T t)
        {
            _queue.Remove(t);
        }

        public void AddToQueue(T t)
        {
            _queue.Add(t);
        }

        public T GetLastInQueue()
        {
            return _queue[_queue.Count - 1];
        }
    }
}
