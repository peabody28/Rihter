using System;

namespace new_and_override_diffs
{
    class A
    {
        public void m_A()
        {
            Console.WriteLine("class A, method m_A");
        }

        public virtual void m_B()
        {
            Console.WriteLine("class A, method m_B");
        }
    }

    class B : A
    {
        // не имеет ничего общего с A.m_A()
        public new void m_A()
        {
            Console.WriteLine("class B, method m_A");
        }

        // переопределение метода базового класса
        public override void m_B()
        {
            Console.WriteLine("class B, method m_B");
        }
    }
    
    class Program
    { 
        static void Main(string[] args)
        {
            // Создаю обьект класса B и привожу его к родительскому
            A cls = new B();
            cls.m_A(); // вызовет метод базового класса
            // на этом этапе компилятор нашел переопределение базового метода и будет использовать его
            cls.m_B(); // вызовет переопределенный метод B.m_B()
            Console.WriteLine();
            
            B cls2 = new B();
            cls2.m_A(); // вызовет метод B.m_A() как отдельный метод класса B
            cls2.m_B(); // вызовет переопределенный метод B.m_B()
        }
    }
}