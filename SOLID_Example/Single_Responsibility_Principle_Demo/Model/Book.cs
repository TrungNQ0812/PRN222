using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_Responsibility_Principle_Demo.Model
{
    public class Book : IBook
    {
        public string title { get; set; }
        
        public string Author { get; set; }
        public double Price { get; set; }
    }
}
