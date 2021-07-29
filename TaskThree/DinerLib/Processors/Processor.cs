using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors
{
    public abstract class Processor : IProcessor
    {
        public abstract ICarrot ProcessCarrot();
        public abstract IOnion ProcessOnion();
    }
}
