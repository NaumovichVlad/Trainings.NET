using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaeCalculatorLib.DataAccess
{
    public interface ICoefficientFileReader
    {
        double[,] ReadACoefficients();
        double[] ReadBCoefficients();
    }
}
