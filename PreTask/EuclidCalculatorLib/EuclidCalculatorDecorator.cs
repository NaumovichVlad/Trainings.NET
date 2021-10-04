using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidCalculatorLib
{
    public abstract class EuclidCalculatorDecorator : EuclidCalculator
    {
        protected EuclidCalculator euclidCalculator;

        public EuclidCalculatorDecorator (EuclidCalculator euclidCalculator)
        {
            this.euclidCalculator = euclidCalculator;
        }
    }
}
