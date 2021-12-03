using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ServerLib.Tcp;
using ServerLib.Tcp.Handlers;
using SlaeCalculatorLib.Calculators;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TaskFourTests.ServerLibTests.DataManagersTests
{
    [TestClass]
    public class ServerTests
    {
        [TestMethod]
        public void Calculate_TestOne()
        {
            var calculator = new GaussMethodParallel();
            var handler = new CalculatorHandler(calculator);
            var server = new Server(8888, IPAddress.Any.ToString(),
                new List<INewClientConnectedHandler>() { handler});
            var testA = JsonConvert.SerializeObject( new double[4, 4]
            {
                { 1, 5, 3, 2 },
                { 8, 4, 2, 5 },
                { 5, 3, 1, 9 },
                { 6, 7, 1, 6 }
            });
            var testB = JsonConvert.SerializeObject( new double[4] { 3, 8, 1, 2 });
            var expected = new double[4] { 335.0 / 293, -135.0 / 293.0, 517.0 / 293.0, -166.0 / 293 };

            Thread thread = new Thread(new ThreadStart(server.Start));
            thread.Start();

            var client = new TcpClient("127.0.0.1", 8888);
            NetworkStream stream = client.GetStream();
            var flag = true;
            while (flag)
            {
                byte[] data = Encoding.Unicode.GetBytes(testA + testB);
                stream.Write(data, 0, data.Length);
                data = new byte[1000];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                var actual = JsonConvert.DeserializeObject<double[]>(builder.ToString());
                Assert.AreEqual(expected.Length, actual.Length);
                for (var i = 0; i < expected.Length; i++)
                    Assert.IsTrue(Math.Abs(expected[i] - actual[i]) <= Math.Pow(10, -10));
                flag = false;
            }
        }
    }
}
