using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Interface_Segregation_Principle_Demo.Model;

namespace Interface_Segregation_Principle_Demo.Utilities
{
    internal class Utilities
    {
        internal static List<Video> ReadData(string fileID)
        {
            var fileName = "D:/Code/PRN222/SOLID_Example/Interface_Segregation_Principle_Demo/Data/BookStore" + fileID +".json";
            var cadJSON = ReadFile(fileName);
            return JsonConvert.DeserializeObject<List<Video>>(cadJSON);
        }
        //-------------------------------------------------------------
        internal static string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
