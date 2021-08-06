using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public class Carrot : Ingredient, ICarrot
    {
        public Carrot (string processingType, int processingTime, DateTime startOfProcessingTime)
            : base (processingType, processingTime, startOfProcessingTime)
        { }
    }
}
