using PrinterLibrary.Printers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class CUI
    {
        private List<Printer> printers;
        public CUI(List<Printer> printers)
        {
            this.printers = printers;
        }
        public void MainMenu()
        {
            var flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("\nВыберите принтер:");
                for (var i = 0; i < printers.Count; i++)
                    Console.WriteLine(string.Format("{0}. {1}", i + 1, printers[i].ToString()));
                int item;
                while (!int.TryParse(Console.ReadLine(), out item))
                    Console.WriteLine("Ошибка! Введите число");
                if (item > 0 && item <= printers.Count)
                {
                    Console.WriteLine(printers[item - 1].Print().ToString());
                    Console.WriteLine("\nХотите продолжить? Нажмите [Y]. Для выхода нажмите любую кнопку");
                    if (!(Console.ReadKey().Key == ConsoleKey.Y))
                        flag = false;
                }    
                else
                    Console.WriteLine("Не верный пункт меню");

            }
        }
    }
}
