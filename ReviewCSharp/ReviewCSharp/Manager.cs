using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReviewCSharp.Employee;
namespace ReviewCSharp
{
    internal class Manager : IManager
    {
        //t<Employee> employees = new List<Employee>();

        ArrayList employees = new ArrayList();

        public int count()
        {

            int count = 0;
            foreach (Employee emp in employees)
            {
                if (emp.gender.ToLower() == "female" && emp.numberOfChildren == 0)
                {
                    count++;
                }
            }
            return count;
        }

        public void delete(int n)
        {
            ArrayList toRemove = new ArrayList();
            foreach (Employee emp in employees)
            {
                if (emp.gender.ToLower() == "male" && emp.numberOfChildren > n)
                {
                    toRemove.Add(emp);
                }
            }

            foreach (Employee emp in toRemove)
            {
                employees.Remove(emp);
            }
        }

        public void inputList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter Employee details:");

                Console.Write("Code: ");
                string code = Console.ReadLine();
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Birth Date (yyyy-mm-dd): ");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Gender (Male/Female): ");
                string gender = Console.ReadLine();
                Console.Write("Number of Children: ");
                int numberOfChildren = int.Parse(Console.ReadLine());
                Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine());

                employees.Add(new Employee(code, name, birthDate, gender, numberOfChildren, salary));
            }
        }

        public void showByName(string name)
        {
            ArrayList searchResult = new ArrayList();
            foreach (Employee emp in employees)
            {
                if (emp.name.ToLower().Contains(name.ToLower()) || emp.name.ToLower().Equals(name.ToLower()))
                {
                    searchResult.Add(emp);
                }
            }

            foreach (Employee emp in searchResult)
            {
                emp.Show();
            }
        }

        public void showList()
        {
            foreach (Employee emp in employees)
            {
                emp.Show();
            }
        }

        public void showSocon(int n)
        {
            foreach (Employee emp in employees)
            {
                if (emp.numberOfChildren < n)
                {
                    emp.Show();
                }
            }
        }

        public void sortBySalary()
        {
            var sortedList = new ArrayList();
            foreach (Employee emp in employees)
            {
                if (emp.gender.ToLower() == "male")
                {
                    sortedList.Add(emp);
                }
            }

            sortedList.Sort(new EmployeeSalaryComparer()); // Sử dụng class so sánh đã tạo

            foreach (Employee emp in sortedList)
            {
                emp.Show();
            }
        }

        public void updateSalary()
        {
            foreach (Employee emp in employees)
            {
                int age = DateTime.Now.Year - emp.doB.Year;
                if (age < 30)
                {
                    emp.salary += emp.salary * 0.05;
                }
                else if (age >= 30 && age < 40)
                {
                    emp.salary += emp.salary * 0.10;
                }
                else
                {
                    emp.salary += emp.salary * 0.15;
                }
            }
        }
    }

    
}
