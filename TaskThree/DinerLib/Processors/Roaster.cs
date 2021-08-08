using DinerLib.DataAccess;
using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors
{
    public class Roaster : Processor
    {
        const int maxSlicer = 5;
        public override ICarrot ProcessCarrot(int processingTime, double costPrice)
        {
            var startOfProcessingTime = CalculateStartTime();
            var ingredient = new FriedCarrot(GetProcessingType(), processingTime, startOfProcessingTime, costPrice);
            AddToQueue(ingredient);
            return ingredient;
        }

        public override IOnion ProcessOnion(int processingTime, double costPrice)
        {
            var startOfProcessingTime = CalculateStartTime();
            var ingredient = new FriedOnion(GetProcessingType(), processingTime, startOfProcessingTime, costPrice);
            AddToQueue(ingredient);
            return ingredient;
        }
        public override IBacon ProcessBacon(int processingTime, double costPrice)
        {
            var startOfProcessingTime = CalculateStartTime();
            var ingredient = new FriedBacon(GetProcessingType(), processingTime, startOfProcessingTime, costPrice);
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
            return ProcessingTypes.Frying;
        }
    }
}
