using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Pattern_Demo.Model
{
    internal interface IMovieReader
    {
        List<Movie> ReadMovies();
    }
}
