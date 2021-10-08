using System;
using System.Security;
using System.Runtime.InteropServices ; 

using System.Text;

namespace StringVsStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            String s1 = "some text";
            StringBuilder s2 = new StringBuilder("some text2");
            using (SecureString ss = new SecureString())
            {
                while (true)
                {
                    ConsoleKeyInfo ck = Console.ReadKey();
                    if (ck.Key == ConsoleKey.Enter) break;

                    ss.AppendChar(ck.KeyChar);
                    Console.Write('*');
                }
                 

            }
        }
    }
}