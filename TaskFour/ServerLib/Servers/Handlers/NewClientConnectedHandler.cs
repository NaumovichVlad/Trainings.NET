using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Tcp.Handlers
{
    public abstract class NewClientConnectedHandler : INewClientConnectedHandler
    {
        public abstract void OnConnected(TcpClient client);
    }
}
