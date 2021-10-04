using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidCalculatorLib
{
    public struct HistogramData
    {
        public readonly TimeSpan euclidMethodTime;
        public readonly TimeSpan binaryEuclidMethodTime;
        public readonly int firstNumber;
        public readonly int secondNumber;

        public HistogramData (TimeSpan euclidMethodTime, TimeSpan binaryEuclidMethodTime, int firstNumber, int secondNumber)
        {
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
            this.binaryEuclidMethodTime = binaryEuclidMethodTime;
            this.euclidMethodTime = euclidMethodTime;
        }
        
    }
}
