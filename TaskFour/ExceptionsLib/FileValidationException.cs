using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLib
{
    public class FileValidationException : Exception
    {
        public FileValidationException()
            : base("The file does not match the template")
        { }
    }
}
