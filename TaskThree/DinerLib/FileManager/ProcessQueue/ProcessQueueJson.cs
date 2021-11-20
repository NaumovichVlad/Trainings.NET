using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.FileManager.ProcessQueue
{
    /// <summary>
    /// class for saving queue state
    /// </summary>
    public class ProcessQueueJson : ProcessQueueConnection
    {
        private readonly string _connectionString;
        public ProcessQueueJson(ProcessingTypes processingType)
        {
            _connectionString = GetPath(processingType);
        }

        public List<DateTime> Load()
        {
            var dateList = new List<DateTime>();
            using (StreamReader sr = new StreamReader(_connectionString))
            {
                var serializer = JsonSerializer.Create();
                JsonReader jr = new JsonTextReader(sr);
                dateList = serializer.Deserialize<List<DateTime>>(jr);
            }
            return dateList;
        }

        public void Save(List<DateTime> timeList)
        {
            var serializer = JsonSerializer.Create();
            using (StreamWriter sw = File.CreateText(_connectionString))
            {
                serializer.Serialize(sw, timeList);
            }
        }
    }
}
