using PrinterLibrary.Prints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterLibrary.Printers
{
    public class LaserPrinter : Printer
    {
        public LaserPrinter(string brand, string model) 
            : base (brand, model)
        { }

        public override Print Print()
        {
            return new LaserPrint();
        }
    }
}
