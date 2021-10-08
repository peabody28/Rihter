using System;

namespace Delegates
{
    class Program
    {
        public delegate void Stat();
        
        static void Main(string[] args)
        {
            var d1 = new Stat(Status);
            d1();
        }

        public static void Status()
        {
            Console.WriteLine("Ok");
        }
    }
}