using System.Net.Sockets;

namespace ServerLib.Tcp.Handlers
{
    public interface INewClientConnectedHandler
    {
        /// <summary>
        /// Processing client joins
        /// </summary>
        /// <param name="client">The joined client</param>
        void OnConnected(TcpClient client);
    }
}