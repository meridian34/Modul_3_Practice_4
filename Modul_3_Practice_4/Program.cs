using System;
using System.Threading.Tasks;
using Modul_3_Practice_4.Helpers;
using Modul_3_Practice_4.Services;

namespace Modul_3_Practice_4
{
    class Program
    {
        static void Main(string[] args)
        {

            Starter starter = new Starter();
            starter.Run();
            Console.ReadKey();
        }
    }
}
