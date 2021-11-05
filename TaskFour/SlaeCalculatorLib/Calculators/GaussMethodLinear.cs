using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaeCalculatorLib.Calculators
{
    public class GaussMethodLinear
    {
        public double[] Compute(double[,] a, double[] b)
        {
            int n = b.Length;
            double[] x = new double[n];

            for (int k = 0; k < n - 1; k++)
            {
                var max = Math.Abs(a[k, k]);
                var maxIndex = k;
                for (int i = k + 1; i < n; i++)
                {
                    if (Math.Abs(a[i, k]) > max)
                    {
                        max = Math.Abs(a[i, k]);
                        maxIndex = i;
                    }
                }

                for (int j = 0; j < n; j++)
                {
                    var temp = a[k, j];
                    a[k, j] = a[maxIndex, j];
                    a[maxIndex, j] = temp;
                }
                var tmp = b[k];
                b[k] = b[maxIndex];
                b[maxIndex] = tmp;

                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k + 1; j < n; j++)
                    {
                        a[i, j] = a[i, j] - a[k, j] * (a[i, k] / a[k, k]);
                    }
                    b[i] = b[i] - b[k] * a[i, k] / a[k, k];
                }
            }

            for (int k = n - 1; k >= 0; k--)
            {
                double sum = 0;
                for (int j = k + 1; j < n; j++)
                    sum += a[k, j] * x[j];
                x[k] = (b[k] - sum) / a[k, k];
            }
            return x;
        }
    }
}
