using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringPogram.Data;

namespace FlooringProgram.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu execute = new Menu();
            execute.StartApplication();
            Console.ReadLine();
        }
    }
}
