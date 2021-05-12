using PrinterLibrary.Prints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterLibrary.Printers
{

    public abstract class Printer
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public Printer(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        public abstract Print Print();

        public override string ToString()
        {
            return string.Format("Фирма: {0}, Модель: {1}", Brand, Model);
        }
    }
}
