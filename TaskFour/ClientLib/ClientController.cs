using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientLib
{
    public class ClientController
    {

        string host;
        int port = 8888;
        TcpClient client;
        NetworkStream stream;
        public ClientController(string host, int port)
        {
            this.host = host;
            this.port = port;
            ConnectToServer();
        }
        private void ConnectToServer()
        {
            client = new TcpClient();
            try
            {
                client.Connect(host, port);
                stream = client.GetStream();
                Thread receiveThread = new Thread(new ThreadStart(SendMessage));
                receiveThread.Start(); //старт потока

                SendMessage();
            }
            catch (Exception)
            {
                Disconnect();
            }
        }
        // отправка сообщений
        void SendMessage()
        {
            Console.WriteLine("Введите сообщение: ");

            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }
        // получение сообщений
        string ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                    Console.WriteLine(message);//вывод сообщения
                }
                catch
                {
                    Console.WriteLine("Подключение прервано!"); //соединение было прервано
                    Console.ReadLine();
                    Disconnect();
                }
            }
        }

        private void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
            Environment.Exit(0);
        }
    }
}
