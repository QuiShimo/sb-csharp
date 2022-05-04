using System;

namespace Exercise_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght;
            int[] array;
            int minNumber = int.MinValue;

            Console.Write("Введите длину последовательности: ");
            lenght = InputNumber();

            array = new int[lenght];

            for(int i = 0; i < array.Length; i++)
            {
                Console.Write("Введите {}-й элемент последовательности: ", i + 1);
                array[i] = InputNumber();
            }

            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] < minNumber) minNumber = array[i];
            }

            Console.WriteLine("Минимальное значение последовательности: {0}", minNumber);
        }

        public static int InputNumber()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
                Console.Write("Повторите ввод: ");

            return number;
        }
    }
}
