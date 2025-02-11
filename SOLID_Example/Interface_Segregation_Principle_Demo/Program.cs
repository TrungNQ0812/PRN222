using Interface_Segregation_Principle_Demo.Model;

namespace Interface_Segregation_Principle_Demo
{
    class Program
    {
        static List<Video> bookList;
        static void PrintBooks(List<Video> books)
        {
            Console.WriteLine("List of Books");
            Console.WriteLine("--------------------------");
            foreach (var item in books) 
            {
                Console.WriteLine($"{item.Title.PadRight(36,' ')}" +
                    $"{item.Author.PadRight(20, ' ')} {item.Price}" + " " + 
                    $"{item.Topic?.PadRight(12, ' ')}" +
                    $"{item.Duration ?? ""}");
            }
            Console.WriteLine();
        }//End of PrintBooks

        static void Main(string[] args)
        {
            string id = string.Empty;
            Console.Title = "Interface Segregation Principle Demo";
            do
            {
                Console.WriteLine("File no. to read: 1/2/3-Enter (Exit): ");
                id = Console.ReadLine();
                if ("123".Contains(id) && !string.IsNullOrEmpty(id))
                {
                    bookList = Utilities.Utilities.ReadData(id);
                    PrintBooks(bookList);
                }
            }while(!string.IsNullOrWhiteSpace(id));
        }//end Main
    }//end program
}
