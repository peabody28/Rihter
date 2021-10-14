using System;
using System.Threading;


//  использование пула потоков CLR
namespace Threads
{
    public class threads_pool
    {
        public static void Caesar()
        {
            Console.WriteLine("Caesar Thread: queuing an asynchronous operation");

            // добавил задачу в пул потоков (CLR сама распределит потоки нужным образом)
            ThreadPool.QueueUserWorkItem(Worker, 5);
            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Caesar Thread: Doing task {0}", i);
                Thread.Sleep(1000);
            }
                
            
            Console.WriteLine("return from Caesar");
        }

        public static void Worker(Object state)
        {
            Console.WriteLine("In Worker: state = {0}", state);
            Thread.Sleep(1000);
            Console.WriteLine("return from Worker");
        }
    }
}