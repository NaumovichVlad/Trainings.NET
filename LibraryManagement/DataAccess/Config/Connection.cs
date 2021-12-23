using Newtonsoft.Json;
using System.IO;

namespace DataAccess.Config
{
    public class Connection
    {
        private const string configFilePath = "../../config.json";

        protected string GetConnection()
        {
            var connectiongString = string.Empty;
            using (StreamReader sr = new(configFilePath))
            {
                connectiongString = sr.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<ConnectionString>(connectiongString).ToString();
        }

        private class ConnectionString
        {
            public string MsSqlConnnection { get; set; }

            public override string ToString()
            {
                return MsSqlConnnection;
            }
        }
    }
}
