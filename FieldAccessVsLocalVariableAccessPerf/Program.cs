using System;
using System.Diagnostics;


namespace FieldAccessVsLocalVariableAccessPerf
{
    class Program
    {
        static void Main()
        {
            const Int64 iter = 5000000000;

            Stopwatch sw = Stopwatch.StartNew();
            TestLocalAccess(iter);
            Console.WriteLine("time taken:{0} ticks", sw.Elapsed);

            sw = Stopwatch.StartNew();
            TestFieldAccess(iter);
            Console.WriteLine("time taken:{0} ticks", sw.Elapsed);
        }

        private static Int64 j;

        public static void TestLocalAccess(Int64 numIncrement)
        {
            Int64 j = 0;
            for (Int64 i = 0; i < numIncrement; i++) j++;
        }

        public static void TestFieldAccess(Int64 numIncrement)
        {
            for (Int64 i = 0; i < numIncrement; i++) j++;
        }
    }
}
