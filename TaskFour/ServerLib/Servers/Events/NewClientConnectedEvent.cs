using System.Net.Sockets;

namespace ServerLib.Tcp.Events
{
    public delegate void ClientDelegate(TcpClient tcpClient);
    public class NewClientConnectedEvent
    {
        /// <summary>
        /// new client connection event
        /// </summary>
        public event ClientDelegate NewClientConnected;

        public void ClientConnecting(TcpClient tcpClient)
        {
            NewClientConnected(tcpClient);
        }
    }
}
