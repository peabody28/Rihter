using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    public class timer2
    {
        public static void Caesar()
        {
            Status();
            for (int i = 0; i < 5; i++)
            {
                    Console.WriteLine("In Main: xxx");
                    Thread.Sleep(1000);
            }
            // мы можем продолжать работу с main
            // программа завершиться по нажатию клавиши
            Console.ReadLine();
        }

        private static async void Status()
        {
            while (true)
            {
                Console.WriteLine("In Status at {0}", DateTime.Now);
                // запрет блокировки потока
                await Task.Delay(1000);
            }
        }
    }
}