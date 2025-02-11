using System;
using System.Linq;
using IoC_Pattern_Demo.Model;

namespace IoC_Pattern_Demo
{
    public class ReaderFactory
    {

        public IMovieReader _IMovieReader { get; }
        public ReaderFactory(string fileType)
        {
            switch (fileType)
            {
                case "XML": 
                    _IMovieReader = new XMLMovieReader();
                    break;
                case "JSON":
                    _IMovieReader = new JSONMovieReader();
                    break;
                default:
                    break;
            }
        }
    }
    class Program
    {
        static IMovieReader _IMovieReader;

        static void Main(string[] args)
        {
            Console.Title = "IoC Pattern";
            Console.WriteLine("Please, select the file type" +
                " to read (1) XML, (2) JSON: ");
            var ans = Console.ReadLine();
            var fileType = (ans == "1") ? "XML" : "JSON";
            _IMovieReader = new ReaderFactory(fileType)._IMovieReader;
            var typeSelected = _IMovieReader.GetType().Name;
            var movieCollection = _IMovieReader.ReadMovies();
            Console.WriteLine($"Movie Titles ({typeSelected})");
            Console.WriteLine("-----------------------------------");
            foreach ( var movie in movieCollection )
            {
                Console.WriteLine($"{movie.id}, {movie.title}, " +
                    $"{movie.oscarNominations}, {movie.oscarWins}");
            }
            Console.ReadLine();
        }//End Main
    }//end program
}
