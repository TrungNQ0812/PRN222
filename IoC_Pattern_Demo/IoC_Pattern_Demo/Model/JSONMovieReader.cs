using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IoC_Pattern_Demo.Model;

namespace IoC_Pattern_Demo.Model
{
    internal class JSONMovieReader : IMovieReader
    {

        static string file = "D:/Code/PRN222/IoC_Pattern_Demo/IoC_Pattern_Demo/Data/MovieDB.json";
        static List<Movie> movies = new List<Movie>();
        public List<Movie> ReadMovies()
        {
            var moviesText = File.ReadAllText(file);
            return JsonSerializer.Deserialize<List<Movie>>(moviesText);
        }
    }
}
