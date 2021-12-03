using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Tcp.Events
{
    public delegate void ClientDelegate(TcpClient tcpClient);
    public class NewClientConnectedEvent
    {
        public event ClientDelegate NewClientConnected;

        public void ClientConnecting(TcpClient tcpClient)
        {
            NewClientConnected(tcpClient);
        }
    }
}
