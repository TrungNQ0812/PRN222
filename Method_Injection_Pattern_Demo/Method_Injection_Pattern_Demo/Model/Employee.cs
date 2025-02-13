using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Injection_Pattern_Demo.Model
{
    public class Employee
    {
        public int EmployeeID;
        public string EmployeeName;
        public IDepartment employeeDept;
        //Default Constructor added for .NET Core DI Container.
        //So that is can automatically create the instance.
        public Employee() { }
        //--------------------------------------
        public Employee(int id, string name)
        {
            EmployeeID = id;
            EmployeeName = name;
        }

        //---------------------------------------

        public void AssignDepartment(IDepartment dept)
        {
            employeeDept = dept ?? throw new ArgumentNullException("null");
            //Other business logic if required
        }
        //----------------------------------------
        public override string ToString()
        {
            return $"EmpID: {EmployeeID}, Emp name: {EmployeeName}," +
                $"Department: {employeeDept.DeptName}";
        }
    }
}
