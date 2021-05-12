using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterLibrary.Prints
{
    public class InjektPrint : Print
    {
        public override string ToString()
        {
            return "Печать по струйной технологии";
        }
    }
}
