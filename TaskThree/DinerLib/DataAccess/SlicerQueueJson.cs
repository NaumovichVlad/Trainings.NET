using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.DataAccess
{
    public class SlicerQueueJson : QueueJson
    {
        public override string ConnectionPath { get { return GetSlicerQueueConnection(); } }
    }
}
