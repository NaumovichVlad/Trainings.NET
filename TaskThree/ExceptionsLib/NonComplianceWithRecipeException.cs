using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLib
{
    public class NonComplianceWithRecipeException : Exception
    {
        public NonComplianceWithRecipeException ()
            : base("The dish does not match the recipe")
        { }
    }
}
