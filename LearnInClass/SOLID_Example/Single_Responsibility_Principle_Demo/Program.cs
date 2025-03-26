using System;
using System.IO;
using Newtonsoft.Json;
using Single_Responsibility_Principle_Demo.Model;

namespace Single_Responsibility_Principle_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List of books:");
            Console.WriteLine("---------------------");
            var cadJSON = File.ReadAllText("D:/Code/PRN222/SOLID_Example/Single_Responsibility_Principle_Demo/Data/BookStore.json");
            var bookList = JsonConvert.DeserializeObject<Book[]>(cadJSON);
            foreach (var item in bookList)
            {
                Console.WriteLine($"{item.title.PadRight(39,' ')}" +
                    $"{item.title.PadRight(15, ' ')} {item.Price}");
            }

            Console.Read();
        }//end Main 
    }
}
