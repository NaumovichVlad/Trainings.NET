using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLib
{
    public class MatrixDemensionException : Exception
    {
        public MatrixDemensionException()
            : base("The dimension of the coefficients A do not coincide")
        { }
    }
}
