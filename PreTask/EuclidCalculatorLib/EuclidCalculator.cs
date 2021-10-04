using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidCalculatorLib
{
    public class EuclidCalculator
    {
        public int CalculateGcd(int firstNumber, int secondNumber)
        {
            if (firstNumber < secondNumber)
            {
                var tmp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = tmp;
            }

            do
            {
                var tmp = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = tmp;
            } while (firstNumber % secondNumber != 0);
            return secondNumber;
        }
    }
}
