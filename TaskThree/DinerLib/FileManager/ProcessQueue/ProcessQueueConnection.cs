using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.FileManager.ProcessQueue
{
    /// <summary>
    /// container with file paths
    /// </summary>
    public class ProcessQueueConnection
    {
        private readonly string _connectionString = "../../../Data/Queues/{0}.json";
        protected string GetPath(ProcessingTypes type)
        {
            return string.Format(_connectionString, type);
        }
    }
}
