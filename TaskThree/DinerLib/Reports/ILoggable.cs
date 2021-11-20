using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Reports
{
    public interface ILoggable
    {
        string LogType { get; }
        DateTime CreateTime { get;}
    }
}
