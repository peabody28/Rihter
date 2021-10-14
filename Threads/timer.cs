using System;
using System.Threading;


namespace Threads
{
    public class timer
    {
        public static System.Threading.Timer s_t;
        
        public static void Caesar()
        {
            s_t = new System.Threading.Timer(Status, null, Timeout.Infinite, Timeout.Infinite);
            s_t.Change(0, Timeout.Infinite);
            // предотвращение завершения процесса
            Console.ReadLine();
        }

        private static void Status(Object state)
        {
            Console.WriteLine("In Status at {0}", DateTime.Now);
            Thread.Sleep(1000);
            s_t.Change(2000, Timeout.Infinite);
        }
    }
}