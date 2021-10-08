using System;

namespace Exceptions
{
    class Program
    {
        public static Double calc(Int32 a, Int32 b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return (double)(a) / b;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Int32 a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("/");
                Int32 b = Convert.ToInt32(Console.ReadLine());
                try
                {
                    calc(a, b);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Вы не можете делить на ноль");
                    continue;
                }
                Double c = calc(a, b);
                Console.WriteLine("="+c);
            }
            
        }
    }
}