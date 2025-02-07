using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Pattern_Demo.Model
{
    internal class Movie
    {
        public string id { get; set; }
        public string title {  get; set; }
        public string oscarNominations { get; set; }
        public string oscarWins { get; set; }
    }
}
