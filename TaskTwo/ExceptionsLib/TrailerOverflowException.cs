using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLib
{
    public class TrailerOverflowException : Exception
    {
        public TrailerOverflowException()
            : base("There is not enough free space in the trailer")
        { }

        public TrailerOverflowException(string message)
            : base(message)
        { }
    }
}
