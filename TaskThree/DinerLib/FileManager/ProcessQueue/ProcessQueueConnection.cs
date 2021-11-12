using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.FileManager.ProcessQueue
{
    public class ProcessQueueConnection
    {
        private readonly string _slicerConnectionString = "../../../Data/Queues/slice_queue.json";
        protected string GetPath(ProcessingTypes type)
        {
            switch (type)
            {
                case ProcessingTypes.Slicing:
                    return _slicerConnectionString;
            }
            return string.Empty;
        }
    }
}
