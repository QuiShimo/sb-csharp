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
                MainMenu(ref employeeData);
            }

        }
        
        private static void MainMenu(ref EmployeeData employeeData)
        {
            Console.Clear();
            Console.WriteLine("======= Главное меню =======");
            Console.WriteLine("1. Добавить запись");
            Console.WriteLine("2. Изменить запись");
            Console.WriteLine("3. Удалить запись");
            Console.WriteLine("4. Просмотреть записи");
            Console.WriteLine("5. Сортировка записей");
            Console.WriteLine("======= Данные =======");
            Console.WriteLine("6. Сохранить записи в файл");
            Console.WriteLine("7. Загрузить записи из файла");

            Console.Write("Введите номер действия: ");
            switch (Console.ReadLine())
            {
                case "1":
                    MenuAddEmployee(employeeData);
                    break;
                case "2":
                    MenuEditEmployee(ref employeeData);
                    break;
                case "3":
                    MenuDeletedEmployee(employeeData);
                    break;
                case "4":
                    Console.Clear();
                    employeeData.CheckEmployee();
                    Console.WriteLine("Нажмите Enter для возврата в главное меню");
                    Console.ReadLine();
                    break;
                case "5":
                    Console.Clear();
                    MenuSortedEmployee(ref employeeData);
                    Console.WriteLine("Нажмите Enter для возврата в главное меню");
                    Console.ReadLine();
                    break;
                case "6":
                    Console.Clear();
                    employeeData.SaveToFile();
                    Console.WriteLine("Записи сохранены в файл");
                    Console.WriteLine("Нажмите Enter для возврата в главное меню");
                    Console.ReadLine();
                    break;
                case "7":
                    Console.Clear();
                    employeeData.LoadData();
                    Console.WriteLine("Записи загруженны из файла");
                    Console.WriteLine("Нажмите Enter для возврата в главное меню");
                    Console.ReadLine();
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

        private static void MenuSortedEmployee(ref EmployeeData employeeData)
        {
            Console.Clear();
            Console.WriteLine("======= Сортировка записей =======");
            Console.WriteLine("1 - Сортировка по ID");
            Console.WriteLine("2 - Сортировка по ФИО");
            Console.WriteLine("3 - Сортировка по возрату");
            Console.WriteLine("4 - Сортировка по росту");
            Console.WriteLine("5 - Сортировка по дате рождения");
            Console.WriteLine("6 - Сортировка по месту рождения");
            Console.WriteLine("7 - Сортировка по дате создания записи");

            employeeData.SortEmployee(Convert.ToInt32(Console.ReadLine()));
        }

        private static void MenuDeletedEmployee(EmployeeData employeeData)
        {
            Console.Clear();
            Console.Write("Введите ID сотрудника, которого нужно удалить: ");
            employeeData.DeleteEmployee(Convert.ToInt32(Console.ReadLine()));
        }

        private static void MenuEditEmployee(ref EmployeeData employeeData)
        {
            Console.Clear();
            Console.WriteLine("Введите ID сотрудника, запись о котором нужно изменить");
            int old_id = Convert.ToInt32(Console.ReadLine());
            Employee tempEmp = employeeData.GetEmploye(old_id);
                      
            Console.WriteLine("Что вы хотите изменить?");
            Console.WriteLine("1 - ID сотрудника");
            Console.WriteLine("2 - ФИО сотрудника");
            Console.WriteLine("3 - Возраст сотрудника");
            Console.WriteLine("4 - Рост сотрудника");
            Console.WriteLine("5 - Дату рождения сотрудника");
            Console.WriteLine("6 - Место рождения сотрудника");
            Console.WriteLine("7 - Дату создания записи сотрудника");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Введите новое значение ID: ");
                    tempEmp.Id = Convert.ToInt32(Console.ReadLine());
                    break;
                case "2":
                    Console.Write("Введите новое значенеи ФИО: ");
                    tempEmp.Name = Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Введите новое значение возраста: ");
                    tempEmp.Age = Convert.ToInt32(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Введите новое значение роста: ");
                    tempEmp.Height = Convert.ToDouble(Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Введите новое значение для даты рождения: ");
                    tempEmp.Birthday = Convert.ToDateTime(Console.ReadLine());
                    break;
                case "6":
                    Console.WriteLine("Введите новое значение для места рождения: ");
                    tempEmp.Birthplace = Console.ReadLine();
                    break;
                case "7":
                    Console.Write("Введите новое значение для даты создания записи: ");
                    tempEmp.DateCreate = Convert.ToDateTime(Console.ReadLine());
                    break;
            }

            employeeData.UpdateEmploye(old_id, tempEmp);
        }
    }
}
