using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib
{
    internal class Client
    {
        public string Id { get; private set; }
        public NetworkStream Stream { get; private set; }
        TcpClient client;
        Server server;
        

        public Client(TcpClient tcpClient, Server server)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            this.server = server;
            server.AddObserver(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                while (true)
                {
                    var data = GetMessage();
                }
            }
            finally
            {
                server.RemoveObserver(this);
                Close();
            }
        }

        public void SendDataToServer()
        {

        }

        private string GetMessage()
        {
            byte[] data = new byte[64];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
            server.RemoveObserver(this);
        }
    }
}
