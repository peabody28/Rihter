using System;

namespace Indexers
{
    class Library
    {
        private String[] books;

        public Library()
        {
            books = new String[100];
        }
        
        public String this[Int32 index]
        {
            get
            {
                if (index < 0 || index >= 100)
                    return null;
                return books[index];
            }
            set
            {
                books[index] = value;
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library();
            lib[0] = "Book1";
            String p = lib[0];
            Console.WriteLine(p);
        }
    }
}