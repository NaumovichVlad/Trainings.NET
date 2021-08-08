using DinerLib.Ingredients;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.DataAccess
{
    public class Queue : IQueue
    {
        private List<IIngredient> _queue;
        public int Count { get { return _queue.Count; } }

        public Queue()
        {
            DeleteReadyMade();
        }

        public IIngredient this[int index]
        {
            get {  return _queue[index]; }
            set { _queue[index] = value; }
        }

        public Queue (List<IIngredient> queueList)
        {
            _queue = queueList;
        }

        public List<IIngredient> ToList()
        {
            return _queue;
        }

        public void DeleteFromQueue(IIngredient ingredient)
        {
            _queue.Remove(ingredient);
        }

        public void AddToQueue(IIngredient ingredient)
        {
            _queue.Add(ingredient);
        }

        public IIngredient GetLastInQueue()
        {
            return _queue[_queue.Count - 1];
        }

        public void DeleteReadyMade()
        {
            DateTime startTime;
            _queue.RemoveAll(i => (startTime = i.StartOfProcessingTime).AddMinutes(i.ProcessingTime) <= DateTime.Now);
        }

        public IEnumerator GetEnumerator()
        {
            return _queue.GetEnumerator();
        }
    }
}
