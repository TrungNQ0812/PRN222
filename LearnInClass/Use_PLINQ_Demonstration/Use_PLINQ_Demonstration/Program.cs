using System;
using System.Linq;
using System.Threading;

namespace Use_PLINQ_Demonstration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var range = Enumerable.Range(1, 1000000);
            //Here issequential version
            var resultList = range.Where(i => i % 3 == 0).ToList();
            Console.WriteLine($"Sequential: Total items are {resultList.Count}");

            //Here is Parallel version using .AsParallel method
            resultList = range.AsParallel().Where(i => i % 3 == 0).ToList();
            Console.WriteLine($"Parallel: Total items are {resultList.Count}");

            resultList = (from i in range.AsParallel()
                          where i % 3 == 0
                          select i).ToList();
            Console.WriteLine($"Parallel: Total items are {resultList.Count}");
            Console.ReadLine();

        }
    }
}
