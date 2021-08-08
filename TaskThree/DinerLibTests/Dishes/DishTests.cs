using DinerLib.Ingredients;
using DinerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DinerLib.Dishes;

namespace DinerLibTests.Dishes
{
    [TestClass]
    public class DishTests
    {
        [TestMethod]
        public void CalculateCostPrice_TestOne()
        {
            var diner = new Diner();
            var order = diner.PrepareAnOrder(new List<DishTypes>() { DishTypes.Salad });
            var actual = order[0].CostPrice;
            Assert.AreEqual(15, actual);
        }

        [TestMethod]
        public void CalculateProcessingTime_TestOne()
        {
            var diner = new Diner();
            var order = diner.PrepareAnOrder(new List<DishTypes>() { DishTypes.Salad });
            var actual = order[0].ProcessingTime;
            Assert.AreEqual(9, actual);
        }
    }
}
