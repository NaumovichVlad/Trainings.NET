using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaeCalculatorLib.Calculators
{
    public interface IGaussMethod
    {
        double[] Compute(double[,] a, double[] b);
    }
}
