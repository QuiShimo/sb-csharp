using System;

namespace SB_Homework03.Exercise_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, score = 0;
            Console.WriteLine("Привет! Сколько у тебя карт?");
            Console.Write("Введите число карт: ");

            while (!int.TryParse(Console.ReadLine(), out n))
                Console.Write("Повторите ввод числа: ");

            Console.WriteLine("Теперь необходимо ввести номинал каждой карты.\n" +
                "Введите 2 - 10 для карт с числовым номиналом\n" +
                "J - Валет, Q - Дама, K - Король, T - Туз");

            for (int i = 0; i < n; i++)
            {
                Console.Write("Номинал {0} карты: ", i + 1);
                string scoreCard = Console.ReadLine();
                switch (scoreCard)
                {
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                        int.TryParse(scoreCard, out int temp);
                        score += temp;
                        break;

                    case "J":
                    case "Q":
                    case "K":
                    case "T":
                        score += 10;
                        break;
                    
                    default:
                        Console.WriteLine("Ошибка! Повторите ввод!");
                        i--;
                        break;
                }
            }

            Console.WriteLine("Сумма карт: {0}", score);
        }
    }
}
