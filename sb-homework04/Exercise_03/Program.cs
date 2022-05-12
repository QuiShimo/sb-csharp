using System;

namespace Exercise_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int trueNumber;

            Console.Write("Введите максимальное целое число диапазона: ");
            trueNumber = random.Next(InputNumber());

            Console.WriteLine("Теперь нужно угадать число...");
            while(true)
            {
                Console.Write("Введите число: ");
                int userNumber = InputNumber();
                if (userNumber == -1)
                {
                    Console.WriteLine("Загаданное число: {0}", trueNumber);
                    break;
                }
                else if (trueNumber == userNumber)
                {
                    Console.WriteLine("Вы угадали число!");
                    break;
                }
                else if (trueNumber < userNumber) Console.WriteLine("Попробуйте ввести число меньше...");
                else Console.WriteLine("Попробуйте ввести число больше...");
            }
        }

        public static int InputNumber()
        {
            int number = -1;
            string str =  Console.ReadLine();

            if (str == "") return -1;

            while (!int.TryParse(str, out number))
                Console.Write("Повторите ввод: ");

            return number;
        }
    }
}
