using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Open_Closed_Principle_Demo.Model;
using Newtonsoft.Json;

namespace Open_Closed_Principle_Demo.Utilities
{
    internal class Utilities
    {
        static string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        //-----------------------------------------------------------------
         internal static List<Book> ReadData()
        {
            var cadJSON = ReadFile("D:/Code/PRN222/SOLID_Example/Open_Closed_Principle_DemoData/BookStore2.json");
            return JsonConvert.DeserializeObject<List<Book>>(cadJSON);
        }

        //-----------------------------------------------------------------
         internal static List<Book> ReadDataExtra()
        {
            List<Book> books = ReadData();
            var cadJSON = ReadFile("D:/Code/PRN222/SOLID_Example/Open_Closed_Principle_DemoData/Data/BookStore2.json");
            books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON));
            return books;
        }
    }
}
