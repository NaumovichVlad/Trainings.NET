using ServerLib.DataManagers;
using SlaeCalculatorLib.Calculators;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerLib.Tcp.Handlers
{
    public class CalculatorHandler : NewClientConnectedHandler
    {
        private readonly ICalculator _calculator;
        public CalculatorHandler(ICalculator calculator)
        {
            _calculator = calculator;
        }
        public override void OnConnected(TcpClient _client)
        {
            Thread clientThread = new Thread(new ParameterizedThreadStart(Process));
            clientThread.Start(_client);
        }

        private void Process(object clientObj)
        {
            var client = (TcpClient)clientObj;
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[64];

                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    var equationsSystem = JsonDataManager.ConvertStringToArrays(builder.ToString());
                    var equationSolution = _calculator.Compute(equationsSystem.A, equationsSystem.B);
                    data = Encoding.Unicode.GetBytes(JsonDataManager.ConvertArrayToString(equationSolution));
                    stream.Write(data, 0, data.Length);
                }
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
    }
}
