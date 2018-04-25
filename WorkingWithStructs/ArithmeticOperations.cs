using System;
using System.Collections.Generic;
using System.Linq;
struct Arithmetic
{
    public static Int64 GetFactorial(Int32 number)
    {
        return number <= 1 ? 1 : number * GetFactorial(number - 1);
    }

    public static IEnumerable<Int32 > GetAllPrimeNumbers(Int32 range)
    {
        return from n in Enumerable.Range(1, range)
               where Enumerable.Range(2, (Int32)Math.Sqrt(n)).All(x => n % x > 0)
               select n;
    }
}