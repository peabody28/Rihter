using System;
using System.Dynamic;

namespace Ref_Out
{
    class Program
    {
        static Int32 Init(out Int32 x)
        {
            return x = 10;
        }

        static Int32 Set(ref Int32 x)
        {
            return x = 12;
        }
        
        static void Main(string[] args)
        {
            Int32 a; // инициализация необязательна
            Init(out a);

            Int32 b = 4; // инициализация необходима
            Set(ref b);
        }
    }
}