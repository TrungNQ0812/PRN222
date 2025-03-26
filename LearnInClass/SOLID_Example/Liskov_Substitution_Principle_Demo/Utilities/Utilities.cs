using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Liskov_Substitution_Principle_Demo.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Liskov_Substitution_Principle_Demo.Utilities
{
    class Utilities
    {
        static string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
        //----------------------------------------------

        internal static List<Book> ReadData()
        {
            var cadJSON = ReadFile("D:/Code/PRN222/SOLID_Example/Liskov_Substitution_Principle_Demo/Data/BookStore.json");
            return JsonConvert.DeserializeObject<List<Book>>(cadJSON);
        }

        //-----------------------------------------------

        internal static List<Book> ReadData(string extra)
        {
            List<Book> books = ReadData();
            var fileName = "D:/Code/PRN222/SOLID_Example/Liskov_Substitution_Principle_Demo/Data/BookStore2.json";
            var cadJSON = ReadFile(fileName);
            books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON)); 
            if(extra == "topic")
            {
                fileName = "D:/Code/PRN222/SOLID_Example/Liskov_Substitution_Principle_Demo/Data/BookStore3.json";
                cadJSON = ReadFile(fileName);
                books.AddRange(JsonConvert.DeserializeObject<List<TopicBook>>(cadJSON));
            }
            return books;
        }


    }
}
