using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DinerLib.FileManager.ProcessQueue;
using System.IO;
using Newtonsoft.Json;

namespace DinerLibTests.FileManager.ProcessQueue
{
    [TestClass]
    public class ProcessQueueJsonTests : ProcessQueueConnection
    {
        [TestMethod]
        public void Save_TestOne()
        {
            var expected = new List<DateTime>
            {
                DateTime.Now,
                DateTime.Now,
                DateTime.Now
            };
            var fileManager = new ProcessQueueJson(DinerLib.ProcessingTypes.Slicing);
            fileManager.Save(expected);
            var connectionString = GetPath(DinerLib.ProcessingTypes.Slicing);
            var actual = new List<DateTime>();
            using (StreamReader sr = new StreamReader(connectionString))
            {
                var serializer = JsonSerializer.Create();
                JsonReader jr = new JsonTextReader(sr);
                actual = serializer.Deserialize<List<DateTime>>(jr);
            }
            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void Load_TestOne()
        {
            var expected = new List<DateTime>
            {
                DateTime.Now,
                DateTime.Now,
                DateTime.Now
            };
            var connectionString = GetPath(DinerLib.ProcessingTypes.Slicing);
            var serializer = JsonSerializer.Create();
            using (StreamWriter sw = File.CreateText(connectionString))
            {
                serializer.Serialize(sw, expected);
            }
            var fileManager = new ProcessQueueJson(DinerLib.ProcessingTypes.Slicing);
            var actual = fileManager.Load();
            for (var i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}
