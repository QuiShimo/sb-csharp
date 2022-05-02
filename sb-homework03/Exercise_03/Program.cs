using System;

namespace Exercise_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            bool isPrimeNumber = true;

            Console.Write("Введите число: ");
            while (!int.TryParse(Console.ReadLine(), out number))
                Console.Write("Повторите ввод числа: ");

            for (int i = 1; i < (int)(number / 2); i++)
            {
                if (number % i == 0) isPrimeNumber = false;

            }

            Console.WriteLine(isPrimeNumber ? "Это число простое" : "Это составное число");

            Console.ReadLine();
        }
    }
}
