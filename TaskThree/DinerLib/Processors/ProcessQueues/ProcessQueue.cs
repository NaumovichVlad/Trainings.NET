using DinerLib.FileManager.ProcessQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors.ProcessQueues
{
    public class ProcessQueue : IProcessQueue
    {
        private readonly int _processingCapacity;
        private readonly double _processTime;
        private readonly ProcessQueueJson _fileManager;
        List<DateTime> _timeList;
        public ProcessQueue(ProcessingTypes processingType, int processingCapacity, double processTime)
        {
            _processingCapacity = processingCapacity;
            _processTime = processTime;
            _fileManager = new ProcessQueueJson(processingType);
            
        }

        public DateTime AddIngredient()
        {
            _timeList = GetQueue();
            var time = DateTime.Now;
            if (_timeList.Count < _processingCapacity)
                time = time.AddMinutes(_processTime);
            else
                time = _timeList[0].AddMinutes(_processTime);
            _timeList.Add(time);
            _fileManager.Save(_timeList);
            return time;
        }

        private List<DateTime> GetQueue()
        {
            var queue = _fileManager.Load();
            if (queue != null)
                return queue.FindAll(d => d > DateTime.Now);
            else
                return new List<DateTime>();
        }

    }
}
