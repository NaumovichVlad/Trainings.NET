using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors
{
    public interface IProcessor
    {
        ICarrot ProcessCarrot(int processingTime, double costPrice);
        IOnion ProcessOnion(int processingTime, double costPrice);
        IBacon ProcessBacon(int processingTime, double costPrice);
        ProcessingTypes GetProcessingType();
    }
}
