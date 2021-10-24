using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLib
{
    public class ObjectExistenceException : Exception
    {
        public ObjectExistenceException()
            : base("The object is not provided by the system")
        { }

        public ObjectExistenceException(string message)
            : base(message)
        { }
    } 
}
