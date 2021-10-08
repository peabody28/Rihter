using System;

namespace operators_override
{
    class Program
    {
        public class Box
        {
            public Int32 lenth;
            public Int32 width;
            public Int32 height;

            public Box(Int32 l, Int32 w, Int32 h)
            {
                this.lenth = l;
                this.width = w;
                this.height = h;
            }
            // перегрузка оператора +
            public static Box operator +(Box b1, Box b2)
            {
                return new Box(b1.lenth + b2.lenth, b1.width + b2.width, b1.height + b2.height);
            }
        }
        static void Main(string[] args)
        {
            Box small = new Box(12, 12, 12);
            Box large = new Box(24, 24, 24);
            Box big = large + small;

            
            Console.WriteLine(big.lenth);
            Console.WriteLine(big.width);
            Console.WriteLine(big.height);
        }
    }
}