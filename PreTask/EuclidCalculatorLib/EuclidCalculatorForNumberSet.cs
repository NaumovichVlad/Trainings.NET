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
        /// <summary>
        /// Calculating GCD for three numbers
        /// </summary>
        /// <returns>GCD</returns>
        public int CalculateGcd(int firstNumber, int secondNumber, int thirdNumber)
        {
            return CalculateGcd(CalculateGcd(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>
        /// Calculating GCD for four numbers
        /// </summary>
        /// <returns>GCD</returns>
        public int CalculateGcd(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber)
        {
            return CalculateGcd(CalculateGcd(firstNumber, secondNumber, thirdNumber), fourthNumber);
        }
        /// <summary>
        /// Calculating GCD for five numbers
        /// </summary>
        /// <returns>GCD</returns>
        public int CalculateGcd(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber, int fifthNumber)
        {
            return CalculateGcd(CalculateGcd(firstNumber, secondNumber, thirdNumber, fourthNumber), fifthNumber);
        }

        /// <summary>
        /// Calculating GCD for two numbers with running time
        /// </summary>
        /// <param name="firstNumber">First natural number</param>
        /// <param name="secondNumber">Second natural number</param>
        /// <param name="calculatingTime">Running time</param>
        /// <returns>GCD</returns>
        public int CalculateGcd(int firstNumber, int secondNumber, out TimeSpan calculatingTime)
        {
            long ellapledTicks = DateTime.Now.Ticks;
            var result = CalculateGcd(firstNumber, secondNumber);
            calculatingTime = new TimeSpan(DateTime.Now.Ticks - ellapledTicks);
            return result;
        }
        /// <summary>
        /// Calculating GCD for two numbers with running time
        /// </summary>
        /// <param name="firstNumber">First natural number</param>
        /// <param name="secondNumber">Second natural number</param>
        /// <param name="calculatingTime">Running time</param>
        /// <returns>GCD</returns>
        public int CalculateGcdBinary(int firstNumber, int secondNumber, out TimeSpan calculatingTime)
        {
            long ellapledTicks = DateTime.Now.Ticks;
            var result = CalculateGcdBinary(firstNumber, secondNumber);
            calculatingTime = new TimeSpan(DateTime.Now.Ticks - ellapledTicks);
            return result;
        }

        private int CalculateGcdBinary(int firstNumber, int secondNumber)
        {
            if (firstNumber == secondNumber || firstNumber == 0)
                return secondNumber;


            if (secondNumber == 0)
                return firstNumber;

            if (CheckIsEven(firstNumber))
            {
                if (CheckIsOdd(secondNumber))
                    return CalculateGcdBinary(firstNumber >> 1, secondNumber);
                else
                    return CalculateGcdBinary(firstNumber >> 1, secondNumber >> 1) << 1;
            }
            else if (CheckIsEven(secondNumber))
            {
                return CalculateGcdBinary(firstNumber, secondNumber >> 1);
            }
            else
            {
                if (firstNumber > secondNumber)
                    return CalculateGcdBinary((firstNumber - secondNumber) >> 1, secondNumber);
                else
                    return CalculateGcdBinary((secondNumber - 1) >> 1, firstNumber);
            }
        }

        private bool CheckIsOdd(int num) => (num & 1) == 1;

        private bool CheckIsEven(int num) => (num & 1) == 0;
        /// <summary>
        /// Preparing to output data for a histogram
        /// </summary>
        /// <param name="firstNumber">First natural number</param>
        /// <param name="secondNumber">Second natural number</param>
        /// <returns>Histogram data</returns>
        public HistogramData GetHistogramData(int firstNumber, int secondNumber)
        {
            TimeSpan euclidMethodTime;
            TimeSpan binaryEuclidTime;
            CalculateGcd(firstNumber, secondNumber, out euclidMethodTime);
            CalculateGcdBinary(firstNumber, secondNumber, out binaryEuclidTime);
            return new HistogramData(euclidMethodTime, binaryEuclidTime, firstNumber, secondNumber);
        }
    }
}
