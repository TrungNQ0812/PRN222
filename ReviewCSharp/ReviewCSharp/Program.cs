
namespace ReviewCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            while (true)
            {
                Console.WriteLine("Manager employees");
                Console.WriteLine("1. TC1 - Enter the employee list");
                Console.WriteLine("2. TC2 - Display the employee list");
                Console.WriteLine("3. TC3- Counts the number of female employees with no allowances");
                Console.WriteLine("4. TC4- Displays employees with the number <given number.");
                Console.WriteLine("5. TC5- Arranging an increasing number of male employees' salaries.");
                Console.WriteLine("6. TC6- Removing male employees according to the number of entries entered from the keyboard.");
                Console.WriteLine("7. TC7- Display employees by name.");
                Console.WriteLine("8. TC8- Update salary");
                Console.WriteLine("9. Exit.");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Emter size of list:");
                        int size = int.Parse(Console.ReadLine());
                        manager.inputList(size);
                        break;
                    case 2:
                        manager.showList();
                        break;
                    case 3:
                        manager.count();
                        break;
                    case 4:
                        Console.WriteLine("emter number of children:");
                        int numberOfChildren = int.Parse(Console.ReadLine());
                        manager.showSocon(numberOfChildren);
                        break;
                    case 5:
                        manager.sortBySalary();
                        break;
                    case 6:
                        Console.WriteLine("Enter number of children: ");
                        int nOC = int.Parse(Console.ReadLine());
                        manager.delete(nOC);
                        break;
                    case 7:
                        Console.WriteLine("What is the name you want to search? ");
                        string name = Console.ReadLine();
                        manager.showByName(name);
                        break;
                    case 8:
                        manager.updateSalary();
                        break;
                    case 9:

                        break;
                }
            }
        }
    
    }
}
