using System;

namespace SlaeCalculatorLib.Calculators
{
    /// <summary>
    /// Solving a system of equations by the Gauss method
    /// </summary>
    public abstract class GaussMethodBase : ICalculator
    {
        /// <summary>
        /// Solve a system of equations
        /// </summary>
        /// <param name="a">Matrix A</param>
        /// <param name="b">Coefficients B</param>
        /// <returns>Array X</returns>
        public abstract double[] Compute(double[,] a, double[] b);

        protected virtual void ExecuteForwardPhaseIteration(double[,] matrix, double[] vector, int iteration)
        {
            var n = vector.Length;
            for (int i = iteration + 1; i < n; i++)
            {
                for (int j = iteration + 1; j < n; j++)
                {
                    matrix[i, j] = matrix[i, j] - matrix[iteration, j] * (matrix[i, iteration] / matrix[iteration, iteration]);
                }
                vector[i] = vector[i] - vector[iteration] * matrix[i, iteration] / matrix[iteration, iteration];
            }
        }

        /// <summary>
        /// Back Phase
        /// </summary>
        protected void ExecuteBackPhaseIteration(double[,] matrix, double[] vector, double[] answers, int iteration)
        {
            double sum = 0;
            var n = vector.Length;
            for (int j = iteration + 1; j < n; j++)
                sum += matrix[iteration, j] * answers[j];
            answers[iteration] = (vector[iteration] - sum) / matrix[iteration, iteration];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix">Matrix A</param>
        /// <param name="iteration">Iteration number</param>
        /// <returns>Max Element</returns>
        protected int FindMainElement(double[,] matrix, int iteration)
        {
            var max = Math.Abs(matrix[iteration, iteration]);
            var maxIndex = iteration;
            for (int i = iteration + 1; i < matrix.GetLength(0); i++)
            {
                if (Math.Abs(matrix[i, iteration]) > max)
                {
                    max = Math.Abs(matrix[i, iteration]);
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        protected void SwapRows(double[,] matrix, double[] vector, int mainRowIndex, int iteration)
        {
            for (int j = 0; j < vector.Length; j++)
            {
                var temp = matrix[iteration, j];
                matrix[iteration, j] = matrix[mainRowIndex, j];
                matrix[mainRowIndex, j] = temp;
            }
            var tmp = vector[iteration];
            vector[iteration] = vector[mainRowIndex];
            vector[mainRowIndex] = tmp;
        }
    }
}
