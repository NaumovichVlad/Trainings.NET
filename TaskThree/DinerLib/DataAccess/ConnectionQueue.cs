using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.DataAccess
{
    /// <summary>
    /// A class with information about the connection string
    /// </summary>
    public class ConnectionQueue
    {
        private string path = @"../../../Data/";

        protected string GetSlicerQueueConnection()
        {
            return path + "slicerQueue.txt";
        }
    }
}
