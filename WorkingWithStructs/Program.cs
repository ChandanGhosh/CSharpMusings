using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithStructs
{
    struct Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Arithmetic.GetFactorial(6));
            Arithmetic.GetAllPrimeNumbers(200).ToList<Int32>().ForEach(num => Console.WriteLine(num));
            Console.Read();
        }
    }
}
