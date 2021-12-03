using System.Net.Sockets;

namespace ServerLib.Tcp.Handlers
{
    public interface INewClientConnectedHandler
    {
        void OnConnected(TcpClient client);
    }
}