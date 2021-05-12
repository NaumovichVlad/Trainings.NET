using PrinterLibrary.Printers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var printers = new List<Printer>() {
                new LaserPrinter("Canon", "A564"),
                new LaserPrinter("Samsung", "S4"),
                new LaserPrinter("LG", "Tech665"),
                new LaserPrinter("HP", "HP7v2"),
                new InjektPrinter("Canon", "A678"),
                new InjektPrinter("Samsung", "S2"),
                new InjektPrinter("LG", "v32.12"),
                new InjektPrinter("HP", "HP8v2"),
                new ThermalPrinter("Canon", "34564"),
                new ThermalPrinter("LG", "L78"),
                new ThermalPrinter("HP", "HP1")
            };
            var cui = new CUI(printers);
            cui.MainMenu();
        }
    }
}
