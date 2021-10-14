using System;
using System.Threading;
using System.Threading.Tasks;


// использование задач Taks для синхронного выполнения
namespace Threads
{
    public class tasks
    {
        public static void Caesar()
        {
            Console.WriteLine("Caesar Thread: queuing an asynchronous operation");

            // добавил задачу в пул потоков (CLR сама распределит потоки нужным образом)
            var a = new Task(Worker, 2);
            a.Start();
            var b = new Task(Worker, 4);
            b.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Caesar Thread: Doing task {0}", "xxx");
                Thread.Sleep(1000);
            }
            
            Thread.Sleep(2000);

            
            // параллельный for
            Parallel.For(0, 10, i => Worker(i));
            
            Console.WriteLine("return from Caesar");
        }

        public static void Worker(Object state)
        {
            Console.WriteLine("In Worker: state = {0}", state);
            Thread.Sleep((Int32)state * 1000);
            Console.WriteLine("return from Worker (state = {0})", state);
        }
    }
}