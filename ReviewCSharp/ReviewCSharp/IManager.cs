using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewCSharp
{
    internal interface IManager
    {
        //Enter an employee list
        void inputList(int size);
        //Show an employee list
        void showList();
        //Count many female employee without allowances
        int count();
        //Display employee with children number < n
        void showSocon(int n);
        //sort the list of employee by salary
        void sortBySalary();
        //remove name of employee in list
        void delete(int n);
        //Find employee by name
        void showByName(string name);
        //Update employee's salary
        void updateSalary();


    }
}
