using System;
using System.IO;

namespace SB_Homework07
{
    internal class Program
    {
        struct Employe
        {
            public int id;
            public string name;
            public int age;
            public int height;
            public string birthday;
            public string birthplace;
            public DateTime dateCreate;
        }

        private static string path = "textfile.txt";

        static void Main(string[] args)
        {
            CheckFileExists();

            bool isWork = true;
            while (isWork)
            {
                Console.WriteLine("========= Меню =========");
                Console.WriteLine("1 - Вывести данные на экран");
                Console.WriteLine("2 - Добавить запись");
                Console.WriteLine("3 - Выход");

                switch (CheckInputNumber())
                {
                    case 1:
                        PrintData();
                        break;
                    case 2:
                        InputData();
                        break;
                    default:
                        isWork = false;
                        break;
                }
            }


        }
    

        private static void PrintData()
        {           
            using (StreamReader sr = new StreamReader(path))
            {
                string? line;

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine("Сотрудник #-{0}\nДобавлен: {1}\nФИО: {2}\n" +
                        "Возраст: {3}\nРост: {4}\nДата рождения: {5}\nМесто Рождения: {6}", line.Split("#"));
                } 
            }
        }

        private static void InputData()
        {
            Console.Write("Введите ID сотрудника: ");
            string str = Console.ReadLine() + "#";
            str += DateTime.Now.ToString() + "#";
            Console.Write("Введите ФИО сотрудника: ");
            str += Console.ReadLine() + "#";
            Console.Write("Введите возраст сотрудника: ");
            str += Console.ReadLine() + "#";
            Console.Write("Введите рост сотрудника: ");
            str += Console.ReadLine() + "#";
            Console.Write("Введите дату рождения сотрудника: ");
            str += Console.ReadLine() + "#";
            Console.Write("Введите место рождения сотрудника: ");
            str += Console.ReadLine();

            WriteToFile(str);

            Console.WriteLine("Информация сохранена!");
        }

        private static void WriteToFile(string text)
        {
            using(StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(text);
            }
        }

        private static void CheckFileExists()
        {
            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }
        }

        private static int CheckInputNumber()
        {

            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
                Console.Write("Повторите ввод: ");

            return number;
        }
    }
}
