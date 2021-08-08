using DinerLib.DataAccess;
using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors
{
    public abstract class Processor : IProcessor
    {
        public abstract ICarrot ProcessCarrot(int processingTime, double costPrice);
        public abstract IOnion ProcessOnion(int processingTime, double costPrice);
        public abstract IBacon ProcessBacon(int processingTime, double costPrice);
        

        protected DateTime CalculatingTimeWhenSpaceAppears(IQueue<IIngredient> queue, int maxProcessors)
        {
            int[] spaces = new int[maxProcessors];
            if (queue.Count >= maxProcessors)
            {
                for (int i = 0; i < maxProcessors; i++)
                {
                    if (queue[i].StartOfProcessingTime < DateTime.Now)
                    {
                        spaces[i] = Convert.ToInt32(queue[i].ProcessingTime - (DateTime.Now - queue[i].StartOfProcessingTime).TotalMinutes);
                    }
                    else
                    {
                        spaces[i] = queue[i].ProcessingTime;
                    }
                }
                for (var i = maxProcessors; i < queue.Count; i++)
                {
                    var minIndex = GetIndexOfMinimumElement(spaces);
                    spaces[minIndex] += queue[i].ProcessingTime;
                }
                return DateTime.Now.AddMinutes(spaces[GetIndexOfMinimumElement(spaces)]);
            }
            else
            {
                return DateTime.Now;
            }
        }

        private int GetIndexOfMinimumElement(int[] array)
        {
            var minElement = array.Min();
            var minIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == minElement)
                {
                    minIndex = i;
                    break;
                }
            }
            return minIndex;       
        }
        public abstract ProcessingTypes GetProcessingType(); 
    }
}
