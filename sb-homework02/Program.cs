using System;

namespace SB_Homework02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Заводим переменные для хранения информации
            // личная информация
            string fullName = "Иваненко Иван Иванович";
            int age = 27;
            string email = "ivanenko@yandex.ru";
            // баллы за предметы
            double programPoints = 36;
            double mathPoints = 47;
            double physPoints = 66;

            // Объявляем и инициализируем переменную для суммы баллов
            double sumPoints = programPoints + mathPoints + physPoints;
            // Считаем средний балл за три предмета
            double averagePoints = sumPoints / 3;

            // вывод данных на экран
            Console.WriteLine("Информация о студенте {0}", fullName);
            Console.WriteLine("Возраст: {0}", age);
            Console.WriteLine("Электронный адрес: {0}", email);
            Console.WriteLine("Баллы за пройденные курсы");
            Console.WriteLine("Программирование: {0}", programPoints);
            Console.WriteLine("Математика: {0}", mathPoints);
            Console.WriteLine("Физика {0}", physPoints);
            Console.WriteLine("-----------");
            Console.WriteLine("Баллов всего: {0}", sumPoints);
            Console.WriteLine("Средний балл: {0:00}", averagePoints);

            Console.ReadKey();
        }
    }
}
