using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB_Homework07
{
    /// <summary>
    /// Данные о сотруднике
    /// </summary>
    internal struct Employee
    {
        /// <summary>
        /// ID сотрудника
        /// </summary>
        private int id;
        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        private int age;
        /// <summary>
        /// Рост сотрудника
        /// </summary>
        private double height;
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        private string name;
        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        private string birthplace;
        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        private DateTime birthday;
        /// <summary>
        /// Дата создания записи
        /// </summary>
        private DateTime dateCreate;

        /// <summary>
        /// Создает запись о сотруднике
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <param name="age">Возраст сотрудника</param>
        /// <param name="height">Рост сотрудника</param>
        /// <param name="name">Имя сотрудника</param>
        /// <param name="birthplace">Место рождения сотрудника</param>
        /// <param name="birthday">Дата рождения сотрудника</param>
        public Employee(int id, int age, double height, string name, string birthplace, DateTime birthday, DateTime dateCreate)
        {
            this.id = id;
            this.age = age;
            this.height = height;
            this.name = name;
            this.birthplace = birthplace;
            this.birthday = birthday;
            this.dateCreate = dateCreate;
        }

        /// <summary>
        /// Вывод информации о сотруднике
        /// </summary>
        public void PrintData()
        {
            Console.WriteLine("Сотрудник #-{0}\nДобавлен: {1}\nФИО: {2}\n" +
                       "Возраст: {3}\nРост: {4}\nДата рождения: {5}\nМесто Рождения: {6}",
                       id, dateCreate, name, age, height, birthday, birthplace);
        }

        public override string ToString()
        {
            return $"{id}#{dateCreate}#{name}#{age}#{height}#{birthday}#{birthplace}";
        }


        public int Id { get { return id; } set { id = value; } }
        public int Age { get { return age; } set { age = value; } }
        public double Height { get { return height; } set { height = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Birthplace { get { return birthplace; } set { birthplace = value;} }
        public DateTime DateCreate { get { return dateCreate; } set { dateCreate = value; } }
        public DateTime Birthday { get { return birthday; } set { birthday = value; } }
    }
}
