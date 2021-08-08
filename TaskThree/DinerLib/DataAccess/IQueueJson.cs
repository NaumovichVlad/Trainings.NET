using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.DataAccess
{
    public interface IQueueJson
    {
        void Save (IQueue queue);
        IQueue Load();
    }
}
