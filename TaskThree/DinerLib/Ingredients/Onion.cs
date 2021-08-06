using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public abstract class Onion : Ingredient, IOnion
    {
        public Onion (string processingType, int processingTime, DateTime startOfProcessingTime)
            : base(processingType, processingTime, startOfProcessingTime)
        { }
    }
}
