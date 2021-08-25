using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLib
{
    internal class Server
    {
        TcpListener listener;
        List<Client> clients = new List<Client>();
        IPAddress localIp;
        int port;

        internal Server (string ip, int port)
        {
            localIp = IPAddress.Parse(ip);
            this.port = port;
        }

        public void AddObserver(Client observer)
        {
            clients.Add(observer);
        }

        public void RemoveObserver(Client observer)
        {
            clients.Remove(observer);
        }
        protected internal void Listen()
        {
            try
            {
                listener = new TcpListener(localIp, port);
                listener.Start();
                while (true)
                {
                    TcpClient tcpClient = listener.AcceptTcpClient();
                    Client clientObject = new Client(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Disconnect();
            }
        }

        protected internal void SendDataToClient(string data, string id)
        {
            byte[] dataByte = Encoding.Unicode.GetBytes(data);
            var client = clients.Find(c => c.Id == id);
            client.Stream.Write(dataByte, 0, dataByte.Length);
        }

        protected internal void Disconnect()
        {
            listener.Stop();
            for (int i = 0; i < clients.Count; i++)
                clients[i].Close();
            Environment.Exit(0);
        }
    }
}
