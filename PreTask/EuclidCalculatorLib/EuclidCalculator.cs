using ExceptionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidCalculatorLib
{
    /// <summary>
    /// Class for calculation GCD of two natural numbers
    /// </summary>
    public class EuclidCalculator
    {
        /// <summary>
        /// Calculation GCD of two natural numbers
        /// </summary>
        /// <param name="firstNumber">First natural number</param>
        /// <param name="secondNumber">Second natural number</param>
        /// <returns>GCD</returns>
        public int CalculateGcd(int firstNumber, int secondNumber)
        {
            if (firstNumber <= 0 || secondNumber <= 0)
                throw new NotNaturalNumberException();

            if (firstNumber < secondNumber)
            {
                var tmp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = tmp;
            }

            while (firstNumber % secondNumber != 0)
            {
                var tmp = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = tmp;
            }
            return secondNumber;
        }
    }
}
