using System;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new { Name = "Abracadabra", Age = 42 };
            Console.WriteLine(a.GetType());
        }
    }
}
