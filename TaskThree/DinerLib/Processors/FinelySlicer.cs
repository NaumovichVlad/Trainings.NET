using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors
{
    public class FinelySlicer : Slicer
    {
        public override ICarrot ProcessCarrot(string processingType, int processingTime)
        {
            var startOfProcessingTime = AddToQueue(processingTime);
            return new FinelyChoppedCarrot(processingType, processingTime, startOfProcessingTime);
        }

        public override IOnion ProcessOnion(string processingType, int processingTime)
        {
            var startOfProcessingTime = AddToQueue(processingTime);
            return new FinelyChoppedOnion(processingType, processingTime, startOfProcessingTime);
        }

        private DateTime AddToQueue(int processingTime)
        {
            return DateTime.Now;
        }
    }
}
