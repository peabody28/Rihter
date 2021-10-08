using System;

namespace Enums
{
    enum Days
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    class Program
    {
        static void Main(string[] args)
        {
            var days = Enum.GetValues(typeof(Days));
            foreach (var day in days)
                Console.WriteLine(day);
        }
    }
}
