using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IoC_Pattern_Demo.Model
{
    internal class XMLMovieReader : IMovieReader
    {
        static string url = @"Data\";
        static XDocument films = XDocument.Load(url + "MoviesDB.xml");
        static List<Movie> movies = new List<Movie>();
        public List<Movie> ReadMovies()
        {
            var movieCollection =
                (from f in films.Descendants("Movie")
                 select new Movie
                 {
                     id = f.Element("id").Value,
                     title = f.Element("title").Value,
                     oscarNominations = f.Element("oscarNominations").Value,
                     oscarWins = f.Element("oscarWins").Value
                 }).ToList();
            return movieCollection;
        }
    }
}
