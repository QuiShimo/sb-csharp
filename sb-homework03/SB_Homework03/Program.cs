using System;

namespace SB_Homework03.Exercise_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine("Приложение по определению чётного или нечётного числа");

            while (true)
            {
                Console.Write("Введите число: ");
                // проверяем удалось ли преобразовать строку в число 
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    // если удалось получить число, проверяем на четность

                    if (number % 2 == 0)
                    {
                        Console.WriteLine("Число четное!");
                    }
                    else
                    {
                        Console.WriteLine("Число нечетное!");
                    }
                    
                    // выходим из цикла
                    break;
                }
                else
                {
                    // если приобразование не удалось, просим повторить ввод числа
                    Console.Write("Повторите ввод числа: ");
                }
            }

            Console.ReadKey();
        }
    }
}
