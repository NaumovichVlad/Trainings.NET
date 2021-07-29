using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors
{
    public interface IProcessor
    {
        ICarrot ProcessCarrot();
        IOnion ProcessOnion();
    }
}
