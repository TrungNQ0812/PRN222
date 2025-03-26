using static Constructor_Injection_Pattern_Demo.Model.DataAccessLayer;
using System;
namespace Constructor_Injection_Pattern_Demo.Model;
{
    class Program
    {
        static void Main(string[] args)
        {
            BookManager bm;
            Console.WriteLine("P1ease, select reading type (XML or JSON)");
            
            var ans = Console.ReadLine();
        if (ans.ToLower() == "xml")
        {
            bm = new BookManager(new )(MLBookReader());
        }else {
            bm = new BookManager(new JSONBookReader());
        }
            bm.ReadBooks();
            Console.ReadLine();
        }
    }
}
