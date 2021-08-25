using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLib
{
    public class ServerController :IServerController
    {
        Server server;
        Thread listenThread;
        public ServerController (string ipAdress, int port)
        {
            server = new Server(ipAdress, port);
        }

        public void Start()
        {
            try
            {
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start();
            }
            catch (Exception)
            {
                server.Disconnect();
            }
        }

        public void SendDataToClient(string  data, string id)
        {
            server.SendDataToClient(data, id);
        }

        public void Stop()
        {
            server.Disconnect();
            
        }
    }
}
