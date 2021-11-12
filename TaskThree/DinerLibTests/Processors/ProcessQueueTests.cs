using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DinerLib.Processors.ProcessQueues;
using DinerLib.FileManager.ProcessQueue;
using System.IO;

namespace DinerLibTests.Processors
{

    [TestClass]
    public class ProcessQueueTests : ProcessQueueConnection
    {
        [TestMethod]
        public void AddIngredients_TestOne()
        {
            using (var sw = File.CreateText(GetPath(DinerLib.ProcessingTypes.Slicing)))
            { };

            var queue = new ProcessQueue(DinerLib.ProcessingTypes.Slicing, 1, 10);
            queue.AddIngredient();
            var actual = queue.AddIngredient();
            var expected = DateTime.Now.AddMinutes(20);
            Assert.AreEqual(expected.Minute, actual.Minute);
        }
    }
}
