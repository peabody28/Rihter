using System;

namespace Rihter
{
    class Program
    {
        static Single NamedParamsTest(Int32 x, Int32 y = 5)
        {
            //asd
            return x * 1.0F / y;
        }
        static void Main(string[] args)
        {
            // x = 1, y = 3
            Single a = NamedParamsTest(1, 3);
            // эквивалентно предыдущему вызову
            // при такой записи не нужно запоминать порядок аргументов
            Single b = NamedParamsTest(y: 3, x: 1);
            
            // a == b
            
            Console.WriteLine(a+"  "+b);
        }
    }
}