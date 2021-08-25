using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerLib;
using System;
using System.Net.Sockets;

namespace ServerLibTests
{
    [TestClass]
    public class SeverControllerTests
    {
        [TestMethod]
        public void Start_TestOne()
        {
            var exceptionFlag = true;
            try
            {
                IServerController serverController = new ServerController("127.0.0.1", 8888);
                serverController.Start();
                TcpClient client = new TcpClient();
                client.Connect("127.0.0.1", 8888);
                serverController.Stop();
            }
            catch (Exception)
            {
                exceptionFlag = false;
            }
            finally
            {
                Assert.IsTrue(exceptionFlag);
            }
        }
    }
}
