using ServerLib.Tcp.Events;
using ServerLib.Tcp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerLib.Tcp
{
    
    public class Server
    {
        private readonly int _port;
        private readonly IPAddress _ipAddress;
        private TcpListener _listener;
        private readonly List<INewClientConnectedHandler> _handlers;
        private readonly NewClientConnectedEvent _clientEvent;

        public Server(int port, string ipAddress, List<INewClientConnectedHandler> handlers)
        {
            _port = port;
            _ipAddress = IPAddress.Parse(ipAddress);
            _handlers = handlers;
            _clientEvent = new NewClientConnectedEvent();
            foreach (var handler in _handlers)
                _clientEvent.NewClientConnected += handler.OnConnected;
        }

        public void Start()
        {
            try
            {
                _listener = new TcpListener(_ipAddress, _port);
                _listener.Start();
                while (true)
                {
                    TcpClient tcpClient = _listener.AcceptTcpClient();
                    _clientEvent.ClientConnecting(tcpClient);
                }
            }
            finally
            {
                if (_listener != null)
                    _listener.Stop();
            }
        }
    }
}

