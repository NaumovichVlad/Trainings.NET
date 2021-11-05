using System;

namespace SlaeCalculatorLib.Calculators
{
    public class GaussMethodLinear : GaussMethodBase
    {
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
    }
}
