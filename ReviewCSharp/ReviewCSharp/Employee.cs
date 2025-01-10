using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReviewCSharp
{
    internal class Employee
    {
       public string code {  get; set; }
        public string name { get; set; }
        public DateTime doB {  get; set; }
        public string gender { get; set; }
        public int numberOfChildren { get; set; }
        public double salary { get; set; }

        public Employee()
        {
            
        }
        public Employee(string code, string name, DateTime doB, string gender, int numberOfChildren, double salary)
        {
            this.code = code;
            this.name = name;
            this.doB = doB;
            this.gender = gender;
            this.numberOfChildren = numberOfChildren;
            this.salary = salary;
        }
        public double CalculateIncome()
        {
            double allowance = 0;
            if (numberOfChildren == 0)
            {
                allowance = 0; // Không có phụ cấp
            }
            else if (numberOfChildren <= 2)
            {
                allowance = 1000000; // Phụ cấp 1 triệu
            }
            else
            {
                allowance = 1500000; // Phụ cấp 1.5 triệu
            }

            return salary + allowance;
        }

        public class EmployeeSalaryComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Employee emp1 = (Employee)x;
                Employee emp2 = (Employee)y;
                return emp1.salary.CompareTo(emp2.salary);
            }
        }


        public void Show()
        {
            Console.WriteLine( "Code : " + code 
                + "\nName: " + name 
                + "\nDate of Birth: " + doB
                + "\nGender: " + gender
                + "\nNumber of children: " + numberOfChildren
                + "\nSalary: " + salary);
        }



    }
}
