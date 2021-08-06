using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.DataAccess
{
    public class ConnectionQueue
    {
        private string path = @"../../../Data/";

        protected string GetSlicerQueueConnection()
        {
            return path + "slicerQueue.txt";
        }
    }
}
