using System;
using System.Collections.Generic;
using System.Text;

namespace KataApplication
{
    public class Programm
    {
        static void Main(string [] args)
        {
            var result = new Trip(new FileOperation()).ConvertResultToReport();
            Console.WriteLine(result);
            Console.Read();

        }
    }
}
