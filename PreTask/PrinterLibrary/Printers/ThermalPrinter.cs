using PrinterLibrary.Prints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterLibrary.Printers
{
    public class ThermalPrinter : Printer
    {
        public ThermalPrinter(string brand, string model)
            : base(brand, model)
        { }

        public override Print Print()
        {
            return new ThermalPrint();
        }
    }
}
