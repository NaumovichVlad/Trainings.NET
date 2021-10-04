using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLib
{
    public class NotNaturalNumberException : Exception
    {
        public NotNaturalNumberException()
            : base("One or more numbers is not natural")
        { }
    }
}
