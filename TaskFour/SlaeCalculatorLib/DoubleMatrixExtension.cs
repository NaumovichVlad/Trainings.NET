using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaeCalculatorLib
{
    public static class DoubleMatrixExtension
    {
        /// <summary>
        /// Getting a range of values
        /// </summary>
        /// <param name="matrix">The original matrix</param>
        /// <param name="firstIndex">Beginning of the range</param>
        /// <param name="lastIndex">Ending of the range</param>
        /// <returns>Double[,] range</returns>
        public static double[,] GetRange(this double[,] matrix, int firstIndex, int lastIndex)
        {
            var range = new double[lastIndex - firstIndex + 1, matrix.GetLength(1)];
            var counter = 0;
            for (var i = firstIndex; i <= lastIndex; i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                    range[counter, j] = matrix[i, j];
                counter++;
            }
            return range;
        }
    }
}
