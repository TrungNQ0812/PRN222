using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Segregation_Principle_Demo.Model
{
    interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        double Price { get; set; }
    }

    //---------------------------------

    interface ITopic
    {
        string Topic { get; set; }
    }

    //----------------------------------

    interface IDuration
    {
        string Duration { get; set; }
    }
}
