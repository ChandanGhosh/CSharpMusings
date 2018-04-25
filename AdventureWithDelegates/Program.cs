using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWithDelegates
{
    class Program
    {
        delegate Int32 Transformer(Int32 x);

        //Contravariance in Delegate
        delegate void StringAction(String s);
        static void Main(string[] args)
        {
            Transformer t = Square;
            var answer = t(3);
            Console.WriteLine(answer);

            //Multi cast delegate
            t += Factorial;
            var factorial = t(6);
            Console.WriteLine(factorial);

            //Another example of Multicast delegate
            ProgressReporter reporter = WriteToConsole;
            reporter += WriteToFile;
            Util.HardWork(reporter);


            //Delegates instance methods target unlike the static methods target as above
            var x = new X();
            ProgressReporter reporter1 = x.InstanceProgress;
            reporter1(99);
            Console.WriteLine(reporter1.Target == x);
            Console.WriteLine(reporter1.Method);

            //Delegate with Contravariance example
            StringAction sa = ActionOnObject;
            sa("Hello");



            Console.Read();
        }

        private static Int32 Square(Int32 number)
        {
            return number * number;
        }

        private static Int32 Factorial(Int32 number)
        {
            
            return number <= 1 ? 1 : number * Factorial(number - 1);
        }

        private static void ActionOnObject(Object o)
        {
            Console.WriteLine("Contravaliance in Delegate : {0}", o);
        }

        private static void WriteToConsole(Int32 percentComplete)
        {
            Console.WriteLine("Percent Complete : {0}", percentComplete);
        }
        
        private static void WriteToFile(Int32 percentComplete)
        {
            System.IO.File.AppendAllText("C:\\progressReport.txt", String.Format("Percent Complete : {0}", percentComplete) + Environment.NewLine);

        }

    }
    public delegate void ProgressReporter(Int32 percentComplete);
    class Util
    {
        public static void HardWork(ProgressReporter p)
        {
            for (int i = 0; i < 10; i++)
            {
                p(i * i);
                Thread.Sleep(1000);
            }
        }
    }

    class X
    {
        public void InstanceProgress(Int32 progressPercentage)
        {
            Console.WriteLine(progressPercentage);
        }
    }
}
