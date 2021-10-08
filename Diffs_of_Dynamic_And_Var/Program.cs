using System;

namespace Diffs_of_Dynamic_And_Var
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic x = "abs"; // строка
            x = 4; // могу неявно изменить тип

            var y = "str"; // тоже строка
            // y = 5; Тип изменить не могу, ошибка 
        }
    }
}