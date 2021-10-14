using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class AsyncFact
    {
        static void Factorial(Int32 num)
        {
            Double result = 1;
            for(int i = 2; i <= num; i++)
                result *= i;
            Thread.Sleep(2000);
            Console.WriteLine($"Факториал равен {result}");
        }
        
        // определение асинхронного метода
        static async void FactorialAsync(Int32 num)
        {
            // await возвращает управление в Main
            await Task.Run(() => Factorial(num));// выполняется асинхронно
        }
            
        public static void Caesar()
        {
            Int32 num;
            while (true)
            {
                num = Convert.ToInt32(Console.ReadLine());
                if (num == -1)
                    break;
                FactorialAsync(num);// вызов асинхронного метода
            }
        }
    }
}