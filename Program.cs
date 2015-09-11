using Nomen.Names.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomen
{
    class Program
    {
        static void Main(string[] args)
        {
            var dng = new DwarvenNameGenerator();

            while (true)
            {
                var name = dng.Generate();
                Console.WriteLine(name.Full);
                Console.ReadKey();
            }
        }
    }
}
