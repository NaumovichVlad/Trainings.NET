using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLib
{
    public class IncorrectTemplateException : Exception
    {
        public IncorrectTemplateException ()
            : base ("The template does not meet the requirements")
        { }
    }
}
