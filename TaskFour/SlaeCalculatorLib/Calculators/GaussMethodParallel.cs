using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaeCalculatorLib.Calculators
{
    /// <summary>
    /// Parallel solution of a system of equations by the Gauss method
    /// </summary>
    public class GaussMethodParallel : GaussMethodBase
    {
        private int _processCount;
        public int ProcessCount
        {
            get => _processCount;
            set => _processCount = value > 0 ? value : throw new ArgumentOutOfRangeException("Process count should be > 0");
        }

        public GaussMethodParallel()
        {
        }

        public override double[] Compute(double[,] a, double[] b)
        {
            int n = b.Length;
            double[] x = new double[n];

            for (var i = 0; i < n - 1; i++)
            {
                var mainRowIndex = FindMainElement(a, i);
                SwapRows(a, b, mainRowIndex, i);
                ExecuteForwardPhaseIteration(a, b, i);
            }

            for (var i = n - 1; i >= 0; i--)
                ExecuteBackPhaseIteration(a, b, x, i);

            return x;
        }

        protected override void ExecuteForwardPhaseIteration(double[,] matrix, double[] vector, int iteration)
        {
            var n = matrix.GetLength(0);
            for (int k = 0; k < n; k++)
            {
                Parallel.For(k + 1, n, j =>
                {
                    double d = matrix[j, k] / matrix[k, k];

                    for (int i = k; i < n; i++)
                    {
                        matrix[j, i] = matrix[j, i] - d * matrix[k, i];
                    }

                    vector[j] = vector[j] - d * vector[k];
                });
            }
        }
    }

    
}
