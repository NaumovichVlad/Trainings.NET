using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLib
{
    public class DishException : Exception
    {
        public DishException()
            : base("This dish does not exist")
        { }
    }
}
