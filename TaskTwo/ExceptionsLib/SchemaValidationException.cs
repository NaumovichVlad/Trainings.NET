using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLib
{
    public class SchemaValidationException : Exception
    {
        public SchemaValidationException() { }

        public SchemaValidationException(string message)
            : base(message) 
        { }
    }
}
