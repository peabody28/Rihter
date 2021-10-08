using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;

namespace Actions
{
    class Program
    {
        // ссылка на функцию (делегат) обработчика события 
        public delegate void Handler(string message);
        public static event Handler Notify = Message;
        
        /*
         * В данном случае Notify привязан к делегату, это как бы и есть делегат,
         * но можно не создавать его обьект а пользоваться простой записью Notify("xxx")
         */
        
        static void Message(String mess) =>
            Console.WriteLine(mess);
        
        public static void In()
        {
            // some code
            Notify("We in!");
        }

        public static void Exit()
        {
            // some code
            Notify("Goodbye!");
        }
        public static void Wow() =>
            Console.Write("Woow!");
        
        public static void Nice() =>
            Console.Write("Nice!");
        
        static void Main(string[] args)
        {
            // делегат = ссылка на функцию
            Action wow = Wow;
            // делегаты могут содержать несколко методов
            wow += Nice;
            wow();
            
            // делегаты используются в связке с событиями
            Console.WriteLine();
            
            In();
            Exit();
            
            Notify("exit program");
        }
    }
}