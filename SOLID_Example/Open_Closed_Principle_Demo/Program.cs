using Open_Closed_Principle_Demo.Model;
using Open_Closed_Principle_Demo.Utilities;
using System;
using System.Collections.Generic;

namespace Open_Closed_Principle_Demo
{
    class Program
    {
        static List<Book> bookList;
        static void PrintBooks(List<Book> books)
        {
            Console.WriteLine("List of books");
            Console.WriteLine("-------------------------");
            foreach (var item in books)
            {
                Console.WriteLine($"{item.Title.PadRight(39, ' ')}" +
                    $"{item.Author.PadRight(20,' ')} {item.Price}");
            }
            Console.ReadLine();
        }//End PrintBooks
        static void Main(string[] args)
        {
            Console.WriteLine("Please, press 'yes' to read and extra file,");
            Console.WriteLine("or any other key for single file");
            var ans = Console.ReadLine();
            bookList = (ans.ToLower() != "yes") ? Utilities.Utilities.ReadData() :
                Utilities.Utilities.ReadDataExtra();
            PrintBooks(bookList);
        }//End Main
    }
}
