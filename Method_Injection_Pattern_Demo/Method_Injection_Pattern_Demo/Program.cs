using System;
using Method_Injection_Pattern_Demo.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Method_Injection_Pattern_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddTransient<IDepartment, Marketing>()
                .AddTransient<Employee>()
                .BuildServiceProvider();

            Employee emp1 = services.GetService<Employee>();
            emp1.EmployeeID = 1;
            emp1.EmployeeName = "Jack";
            emp1.AssignDepartment(services.GetService<IDepartment>());

            Employee emp2 = services.GetService<Employee>();
            emp2.AssignDepartment(services.GetService<IDepartment>());
            emp2.EmployeeID = 2;
            emp2.EmployeeName = "David";

            Console.WriteLine(emp1);
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(emp2);
            Console.ReadLine();
        }//End main
    }//End program
}