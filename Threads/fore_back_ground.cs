using System;
using System.Threading;

// создание дополнительных потоков
namespace Threads
{
    public class fore_back_ground
    {
        public static void Caesar()
        {
            Thread t = new Thread(Worker);
            
            // если поток фоновый программа завершит работу
            // независимо от того выплнен он или нет
            t.IsBackground = true;
            
            
            t.Start();
            
            Console.WriteLine("Return from Caesar");
        }
    
        public static void Worker()
        {
            Thread.Sleep(10000);
            Console.WriteLine("Return from Worker");
        }
    }
}