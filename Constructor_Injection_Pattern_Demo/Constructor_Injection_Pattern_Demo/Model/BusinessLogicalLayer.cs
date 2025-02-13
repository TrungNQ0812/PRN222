using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Constructor_Injection_Pattern_Demo.Model;

namespace Constructor_Injection_Pattern_Demo.Model
{
    internal class BusinessLogicalLayer
    {


        public IBookReader bookReader;
        //Constructor Injection
        public BookManager(IBookReader reader)
        {
            bookReader = reader;
        }
        public void ReadBooks()
        {
            bookReader.ReadBooks();
        }
    }
        
}
