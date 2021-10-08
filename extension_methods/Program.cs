using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace extension_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder a = new StringBuilder("asd#dad");
            Console.WriteLine(a.IndexOf('x'));
            Console.WriteLine(a.IndexOf('#'));
        }
        
        
    }

    // любое названия класса, для использования метода это не принипиально
    public static class StringBuilderExtension
    {
        public static Int32 IndexOf(this StringBuilder str, Char ch)
        {
            for(Int32 i = 0; i<str.Length; i++)
                if (str[i] == ch)
                    return i;
            return -1;
        }
    }

}