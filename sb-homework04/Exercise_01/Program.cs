using System;

namespace Exercise_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m, sum = 0;
            int[,] matrix;
            Random random = new Random();

            Console.Write("Введите количество строк: ");
            n = InputNumber();

            Console.Write("Введите количество столбцов: ");
            m = InputNumber();

            matrix = new int[n, m];

            Console.WriteLine("Вывод матрицы размером {0}x{1}", n, m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = random.Next(0, 10);
                    sum += matrix[i, j];
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Сумма элементов: {0}", sum);
        }

        private static int InputNumber()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
                Console.Write("Повторите ввод: ");

            return number;
        }
    }
}
