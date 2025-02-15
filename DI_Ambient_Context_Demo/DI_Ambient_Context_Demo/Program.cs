using System;
using DI_Ambient_Context_Demo.Model;
using Microsoft.Extensions.DependencyInjection;
namespace DI_Ambient_Context_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddTransient<Employee>()
                .AddTransient<MarketingProvider>()
                .AddTransient<DefaultDepartmentProvider>()
                .BuildServiceProvider();
            //Set the current value by resolving with MarketingProvider.
            Provider.Current = services.GetService<MarketingProvider>();
            Employee emp1 = services.GetService<Employee>();
            emp1.EmployeeID = 1;
            emp1.EmployeeName = "Jack";
            emp1.EmployeeDept = Provider.Current.Department;

            Employee emp2 = services.GetService<Employee>();
            emp2.EmployeeID = 2;
            emp2.EmployeeName = "David";
            emp2.EmployeeDept = Provider.Current.Department;

            Console.WriteLine(emp1);
            Console.WriteLine(new string('-',20));
            Console.WriteLine(emp2);
            Console.ReadLine();
        }//End Main
    }//End Program
}