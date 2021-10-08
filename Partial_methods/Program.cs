using System;

namespace Partial_methods
{
    /* допустим мы хотим переопределить некий метод в базовом классе.
     Однако мы не можем сделать этот класс статическим или запечатанным sealed
     Что накладывает на нас ограничения.
     На помощь приходят Частичные (partial) методы
    */

    // запечатанный класс
    sealed partial class Base
    {
        public static partial void Method();

        public void CallMethod()
        {
            Method();
        }
    }

    sealed partial class Base
    {
        public static partial void Method()
        {
            Console.WriteLine("Hello i'm partial method!");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Base b = new();
            b.CallMethod();
            Base.Method();
        }
    }
}