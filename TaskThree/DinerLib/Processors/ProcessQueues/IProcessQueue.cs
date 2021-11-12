using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors.ProcessQueues
{
    public interface IProcessQueue
    {
        DateTime AddIngredient();
    }
}
