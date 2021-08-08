using DinerLib.DataAccess;
using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors
{
    public class CoarselySlicer : Slicer
    {
        const int maxSlicer = 5;
        public override ICarrot ProcessCarrot(int processingTime, double costPrice)
        {
            var startOfProcessingTime = CalculateStartTime();
            var ingredient = new CoarselyChoppedCarrot(GetProcessingType(), processingTime, startOfProcessingTime, costPrice);
            AddToQueue(ingredient);
            return ingredient;
        }

        public override IOnion ProcessOnion(int processingTime, double costPrice)
        {
            var startOfProcessingTime = CalculateStartTime();
            var ingredient = new CoarselyChoppedOnion(GetProcessingType(), processingTime, startOfProcessingTime, costPrice);
            AddToQueue(ingredient);
            return ingredient;
        }

        public override IBacon ProcessBacon(int processingTime, double costPrice)
        {
            var startOfProcessingTime = CalculateStartTime();
            var ingredient = new CoarselyChoppedBacon(GetProcessingType(), processingTime, startOfProcessingTime, costPrice);
            AddToQueue(ingredient);
            return ingredient;
        }

        private DateTime CalculateStartTime()
        {
            IQueueJson queueJson = new SlicerQueueJson();
            var queue = queueJson.Load();
            var startTime = CalculatingTimeWhenSpaceAppears(queue, maxSlicer);
            return startTime;
        }

        private void AddToQueue(IIngredient ingredient)
        {
            IQueueJson queueJson = new SlicerQueueJson();
            var queue = queueJson.Load();
            queue.AddToQueue(ingredient);
            queueJson.Save(queue);
        }

        public override ProcessingTypes GetProcessingType()
        {
            return ProcessingTypes.CoarseSlicing;
        }
    }
}
