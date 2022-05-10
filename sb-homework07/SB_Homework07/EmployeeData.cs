using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SB_Homework07
{
    internal struct EmployeeData
    {
        /// <summary>
        /// путь сохранения списка
        /// </summary>
        private string path;
        /// <summary>
        /// Список сотрудников
        /// </summary>
        private List<Employee> employees;
        

        public EmployeeData(string path)
        {
            this.path = path;
            employees = new List<Employee>();
        }

        public void AddEmployee(Employee emp)
        {
            employees.Add(emp);
        }

        public Employee GetEmploye(int id)
        {
           return employees.Find(x => x.Id == id);
        }

        public void UpdateEmploye(int id, Employee newEmp)
        {
            employees = employees.OrderBy(x => x.Id).ToList();
            employees.RemoveAt(id - 1);
            employees.Add(newEmp);
        }

        public void DeleteEmployee(int id)
        {
            Employee deleteEmp = employees.Find(x => x.Id == id);
            employees.Remove(deleteEmp);
        }

        public void CheckEmployee()
        {
            if (employees.Count > 0)
            {
                foreach (Employee emp in employees)
                    emp.PrintData();
            }
        }

        public void SortEmployee(int n)
        {
            switch (n)
            {
                case 1:
                    employees = employees.OrderByDescending(x => x.Id).ToList();
                    break;
                case 2:
                    employees = employees.OrderByDescending(x => x.Name).ToList();
                    break;
                case 3:
                    employees = employees.OrderByDescending(x => x.Age).ToList();
                    break;
                case 4:
                    employees = employees.OrderByDescending(x => x.Height).ToList();
                    break;
                case 5:
                    employees = employees.OrderByDescending(x => x.Birthday).ToList();
                    break;
                case 6:
                    employees = employees.OrderByDescending(x => x.Birthplace).ToList();
                    break;
                case 7:
                    employees = employees.OrderByDescending(x => x.DateCreate).ToList();
                    break;
            }
        }


        public void SaveToFile()
        {
            if(employees.Count > 0)
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    foreach (Employee emp in employees)
                    {
                        sw.WriteLine(emp.ToString());
                    }
                }
            }
        }

        public void LoadData()
        {
            FileInfo fi = new FileInfo(path);

            if (fi.Exists)
            {
                using (StreamReader sr = new StreamReader(fi.FullName))
                {
                    string? line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split('#');
                        AddEmployee(
                            new Employee(
                            Convert.ToInt32(data[0]),
                            Convert.ToInt32(data[3]),
                            Convert.ToDouble(data[4]),
                            data[2],
                            data[6],
                            Convert.ToDateTime(data[5]),
                            Convert.ToDateTime(data[1])));
                    }
                }
            }
        }
    }
}
