using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Channels;

namespace ActionsChanel
{
    // класс хранящий данные сообщения
    public class MessageEventArgs : EventArgs
    {
        private readonly String from, text;

        public MessageEventArgs(String from, String text)
        {
            this.from = from;
            this.text = text;
        }
        
        public string From
        {
            get
            {
                return from;
            }
        }

        public string Text
        {
            get
            {
                return text;
            }
        }
    }
    
    // класс может генерировать сообщения, обрабатывать подписки и отписки
    class Chanel
    {
        private EventHandler<MessageEventArgs> newMess;
        
        public event EventHandler<MessageEventArgs> Message
        {
            add
            {
                newMess += value;
            }
            remove
            {
                newMess -= value;
            }
        }

        
        // этот метод отправляет событие
        public void OnNewMessage(MessageEventArgs e)
        {
            EventHandler<MessageEventArgs> temp = Volatile.Read(ref newMess);
            
            // если хоть кто-то подписан на событие, произойдет генерация события
            if (temp != null)
                temp(this, e); // генерация события
        }

        // создание сообщения
        public void SimulateMessage(String from, String text)
        {
            MessageEventArgs e = new MessageEventArgs(from, text);
            OnNewMessage(e);
        }
        
    }

    // класс который способен обрабатывать событие, если на него подписан
    class Human1
    {
        
        public Human1(Chanel ch)
        {
            // подписка на уведомления
            ch.Message += GetMess;
        }

        public void GetMess(Object ch, MessageEventArgs e)
        {
            Console.WriteLine("Human1 is get mess!");
            Console.WriteLine("from {0}, text {1}", e.From, e.Text);
        }
        
        // метод, позволяющий отписаться от метода
        public void Unregister(Chanel ch)
        {
            ch.Message -= GetMess;
        }
    }
    
    // класс который способен обрабатывать событие, если на него подписан
    class Human2
    {
        
        public Human2(Chanel ch)
        {
            // подписка на уведомления
            ch.Message += GetMess;
        }

        public void GetMess(Object ch, MessageEventArgs e)
        {
            Console.WriteLine("Human2 is get mess!");
            Console.WriteLine("from {0}, text {1}", e.From, e.Text);
        }

        // метод, позволяющий отписаться от метода
        public void Unregister(Chanel ch)
        {
            ch.Message -= GetMess;
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Chanel ch = new Chanel();
            
            // при создании обьектов следующих классов, они автоматически подписываются на события ch
            Human1 h1 = new Human1(ch);
            Human2 h2 = new Human2(ch);
            
            // генерирую сообщение, а следовательно и событие
            ch.SimulateMessage("Alex", "Hello i'm alex!");
            // отписка от события ch
            h1.Unregister(ch);
            ch.SimulateMessage("Maria", "Hello i'm Maria!");
        }
    }
}