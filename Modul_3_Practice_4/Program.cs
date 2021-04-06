using System;
using Modul_3_Practice_4.Helpers;

namespace Modul_3_Practice_4
{
    public class Program
    {
        public void Main()
        {
            Starter starter = new Starter();
            starter.Run().GetAwaiter().GetResult();
            Console.ReadKey();
        }
    }
}
