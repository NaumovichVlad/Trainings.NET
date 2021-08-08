using DinerLib;
using DinerLib.DataAccess;
using DinerLib.Ingredients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace DinerLibTests.DataAccess
{
    [TestClass]
    public class QueueJsonTests
    {
        [TestMethod]
        public void SlicerQueueSave_TestOne()
        {
            var queueJson = new SlicerQueueJson();
            var queueList = new List<IIngredient>();
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Parse("Jan 1, 2021"), 10));
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 20, DateTime.Parse("Dec 3, 2020"), 10));
            queueJson.Save(new Queue(queueList));
            string actual = string.Empty;
            string expected = string.Empty;
            using (StreamReader sr = new StreamReader(queueJson.ConnectionPath))
                actual = sr.ReadToEnd();
            using (StreamReader sr = new StreamReader("../../Data/SlicerQueueForTests.txt"))
                expected = sr.ReadToEnd();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SlicerQueueLoad_TestOne()
        {
            var queueList = new List<IIngredient>();
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Parse("Jan 1, 2021"), 10));
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 20, DateTime.Parse("Dec 3, 2020"), 10));
            var expected = new Queue(queueList);
            var queueJson = new SlicerQueueJson();
            queueJson.Save(expected);
            var actual = queueJson.Load();
            Assert.AreEqual(expected.ToList().Count, actual.ToList().Count);
            for (int i = 0; i < expected.ToList().Count; i++)
                Assert.AreEqual(expected.ToList()[i], actual.ToList()[i]);
        }
    }
}
