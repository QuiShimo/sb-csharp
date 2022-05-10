using System;
using System.IO;

namespace SB_Homework07
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool isWork = true;
            EmployeeData employeeData = new EmployeeData("text.txt");

            while (isWork)
            {
                MainMenu(employeeData);
            }

        }
        
        private static void MainMenu(EmployeeData employeeData)
        {
            Console.Clear();
            Console.WriteLine("======= Главное меню =======");
            Console.WriteLine("1. Добавить запись");
            Console.WriteLine("2. Просмотреть записи");
            Console.WriteLine("======= Данные =======");
            Console.WriteLine("4. Сохранить записи в файл");
            Console.WriteLine("5. Загрузить записи из файла");

            Console.Write("Введите номер действия: ");
            switch (Console.ReadLine())
            {
                case "1":
                    MenuAddEmployee(employeeData);
                    break;
                case "2":
                    Console.Clear();
                    employeeData.CheckEmployee();
                    Console.WriteLine("Нажмите Enter для возврата в главное меню");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Clear();
                    employeeData.SaveToFile();
                    Console.WriteLine("Записи сохранены в файл");
                    break;
                case "5":
                    Console.Clear();
                    employeeData.LoadData();
                    Console.WriteLine("Записи загруженны из файла");
                    break;
            }
        }

        private static void MenuAddEmployee(EmployeeData employeeData)
        {
            Console.Clear();
            Console.WriteLine("======= Добавление записи =======");
            Console.Write("Введите ID сотрудника: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ФИО сотрудника: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст сотрудника: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите рост сотрудника: ");
            double height = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите дату рождения сотрудника: ");
            DateTime birthday = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Введите место рождения сотрудника: ");
            string birthPlace = Console.ReadLine();

            employeeData.AddEmployee(new Employee(id, age, height, name, birthPlace, birthday, DateTime.Now));

            Console.WriteLine("Запись добавлена, нажмите Enter для возврата в главное меню");
            Console.ReadLine();
        }
    }
}
