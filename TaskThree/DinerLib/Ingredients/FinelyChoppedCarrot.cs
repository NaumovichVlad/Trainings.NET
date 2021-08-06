using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public class FinelyChoppedCarrot : Carrot, IFinelyChoppedCarrot
    {
        public FinelyChoppedCarrot (string processingType, int processingTime, DateTime startOfProcessingTime)
            : base (processingType, processingTime, startOfProcessingTime)
        { }
    }
}
