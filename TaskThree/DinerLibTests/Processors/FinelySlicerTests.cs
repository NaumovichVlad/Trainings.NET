using DinerLib;
using DinerLib.DataAccess;
using DinerLib.Ingredients;
using DinerLib.Processors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DinerLibTests.Processors
{
    [TestClass]
    public class FinelySlicerTests
    {
        [TestMethod]
        public void ProcessIngredient_TestOne()
        {
            var queueList = new List<IIngredient>();
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now.AddMinutes(10), 10));
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now.AddMinutes(10), 10));
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now.AddMinutes(10), 10));
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now.AddMinutes(10), 10));
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now.AddMinutes(10), 10));
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now.AddMinutes(20), 10));
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now.AddMinutes(20), 10));
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now.AddMinutes(20), 10));
            var queueJson = new SlicerQueueJson();
            queueJson.Save(new Queue(queueList));
            var slicer = new FinelySlicer();
            var actual = slicer.ProcessOnion(10, 10);
            var expected = new FinelyChoppedOnion(ProcessingTypes.FineSlicing, 10, DateTime.Now.AddMinutes(10), 10);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ProcessIngredient_TestTwo()
        {
            var queueList = new List<IIngredient>();
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now.AddMinutes(10), 10));
            queueList.Add(new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now.AddMinutes(10), 10));
            var queueJson = new SlicerQueueJson();
            queueJson.Save(new Queue(queueList));
            var slicer = new FinelySlicer();
            var actual = slicer.ProcessOnion(10, 10);
            var expected = new FinelyChoppedOnion(ProcessingTypes.FineSlicing, 10, DateTime.Now, 10);
            Assert.AreEqual(actual, expected);
        }
    }
}
