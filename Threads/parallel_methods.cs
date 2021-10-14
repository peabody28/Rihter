using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    public class parallel_methods
    {

        public static void Caesar()
        {
            Console.WriteLine("Start parallel work");
            Parallel.Invoke(()=>M1(null), ()=>M2(null), ()=>M3(null));
            Console.WriteLine("End parallel work");
        }
        public static void M1(Object state)
        {
            Console.WriteLine("In M1");
            Thread.Sleep(2000);
            Console.WriteLine("Return from M1");
        }
        
        public static void M2(Object state)
        {
            Console.WriteLine("In M2");
            Thread.Sleep(2000);
            Console.WriteLine("Return from M2");
        }
        
        public static void M3(Object state)
        {
            Console.WriteLine("In M3");
            Thread.Sleep(2000);
            Console.WriteLine("Return from M3");
        }
        
    }
}