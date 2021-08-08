using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public class CoarselyChoppedOnion : Onion, ICoarselyChoppedOnion
    {
        public CoarselyChoppedOnion(ProcessingTypes processingType, int processingTime, DateTime startOfProcessingTime, double costPrice)
            : base(processingType, processingTime, startOfProcessingTime, costPrice)
        { }
    }
}
