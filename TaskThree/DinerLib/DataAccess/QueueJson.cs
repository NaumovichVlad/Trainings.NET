using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DinerLib.DataAccess
{
    abstract public class QueueJson : ConnectionQueue, IQueueJson
    {
        abstract public string ConnectionPath { get; }

        public IQueue<IIngredient> Load()
        {
            var queueList = new List<IIngredient>();
            using(StreamReader sr = new StreamReader(ConnectionPath))
            {
                string ingredient;
                while ((ingredient = sr.ReadLine()) != null)
                    queueList.Add(JsonSerializer.Deserialize<Ingredient>(ingredient));
            }
            return new Queue<IIngredient>(queueList);
        }

        public void Save(IQueue<IIngredient> queue)
        {
            var queueList = queue.ShowQueue();
            using (StreamWriter sw = new StreamWriter(ConnectionPath))
            {
                foreach (var ingredient in queueList)
                    sw.WriteLine(JsonSerializer.Serialize(ingredient));
            }
        }
    }
}
