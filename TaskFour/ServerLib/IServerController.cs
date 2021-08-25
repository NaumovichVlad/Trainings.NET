using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib
{
    public interface IServerController
    {
        void Start();
        void SendDataToClient(string data, string id);
        void Stop();
    }
}
