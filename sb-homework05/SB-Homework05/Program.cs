using System;

namespace SB_Homework05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите предложение: ");
            string inputPhrase = Console.ReadLine();

            Console.WriteLine("Предложение по словам:");
            PrintWords(SplitString(inputPhrase));

            Console.WriteLine("Предложение по словам, в обратном порядке:");
            PrintWords(ReversWords(inputPhrase));
        }

        public static string[] SplitString(string inputPhrase)
        {
            return inputPhrase.Split(' ');
        }

        public static void PrintWords(string[] words)
        {
            foreach (string word in words)
                Console.WriteLine(word);
        }

        public static string[] ReversWords(string inputPhrase)
        {
            string[] reverseString;

            reverseString = SplitString(inputPhrase);
            Array.Reverse(reverseString);

            return reverseString;
        }
    }
}
