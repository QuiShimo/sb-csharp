using System;

namespace SB_Homework03.Exercise_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;

            Console.WriteLine("Приложение по определению чётного или нечётного числа\nВведите число: ");
            
            while (!int.TryParse(Console.ReadLine(), out number))
                Console.Write("Повторите ввод числа: ");

            Console.WriteLine(number % 2 == 0 ? "Число четное!" : "Число нечетное!");

            Console.ReadKey();
        }
    }
}
