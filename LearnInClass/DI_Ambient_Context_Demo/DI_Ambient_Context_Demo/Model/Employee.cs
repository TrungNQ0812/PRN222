using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Ambient_Context_Demo.Model
{
    public class Employee
    {
        public int EmployeeID;
        public string EmployeeName;
        public IDepartment EmployeeDept;
        //Default Constructor added for .NET Core DI Container.
        // So that it can automatically create the instance.
        public Employee(){}
        //------------------------------------------------
        public Employee(int id, string name)
        {
            EmployeeID = id;
            EmployeeName = name;
        }
        //-------------------------------------------------
        public void AssignDepartment(IDepartment dept)
        {
            EmployeeDept = dept ?? throw new ArgumentNullException("Null");
            //Other business logic if required.
        }
        //--------------------------------------------------
        public override string ToString()
        {
            return $"EmpID: {EmployeeID}, Emp name: {EmployeeName}," +
                $"Department: {EmployeeDept.DeptName}";
        }
    }
}
