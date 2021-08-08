using DinerLib;
using DinerLib.Ingredients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLibTests.Ingredients
{
    [TestClass]
    public class IngredientTests
    {
        [TestMethod]
        public void Equals_TestOne()
        {
            var firstIngredient = new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now, 10);
            var secondIngredient = new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now, 10);
            Assert.AreEqual(true, firstIngredient.Equals(secondIngredient));
        }
        public void Equals_TestTwo()
        {
            var firstIngredient = new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now, 10);
            var secondIngredient = new FinelyChoppedCarrot(ProcessingTypes.FineSlicing, 10, DateTime.Now.AddSeconds(2), 10);
            Assert.AreEqual(false, firstIngredient.Equals(secondIngredient));
        }
    }
}
