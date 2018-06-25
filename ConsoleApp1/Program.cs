using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = new Word();
            Console.WriteLine(res.IsCardPassed.Length);
            foreach (var item in res.IsCardPassed)
            {
                Console.WriteLine(item);
            }
        }
    }
}
