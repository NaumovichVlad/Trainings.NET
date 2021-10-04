using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidCalculatorLib
{
    public class EuclidCalculatorForNumberSet : EuclidCalculatorDecorator
    {
        public EuclidCalculatorForNumberSet(EuclidCalculator euclidCalculator)
            : base(euclidCalculator)
        { }

        public int CalculateGcd(int firstNumber, int secondNumber, int thirdNumber)
        {
            return 0;
        }
    }
}
