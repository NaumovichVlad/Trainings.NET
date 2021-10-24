using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLib
{
    public class TrailerExistenceExeption : Exception
    {
        public TrailerExistenceExeption(string message)
            : base(message)
        { }
    }
}
