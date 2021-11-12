using DinerLib.FileManager.ProcessQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors.ProcessQueues
{
    internal class ProcessQueue
    {
        private readonly int _processingCapacity;
        private readonly double _processTime;
        private readonly ProcessQueueJson _fileManager;
        public ProcessQueue(ProcessingTypes processingType, int processingCapacity, double processTime)
        {
            _processingCapacity = processingCapacity;
            _processTime = processTime;
            _fileManager = new ProcessQueueJson(processingType);
        }

    }
}
