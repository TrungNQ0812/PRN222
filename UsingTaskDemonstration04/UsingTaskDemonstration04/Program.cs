﻿namespace UsingTaskDemonstration04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<Task<int>>();
            var source = new CancellationTokenSource();
            var token = source.Token;
            int completeIterations = 0;

            for (int n = 1; n <= 20; n++)
            {
                tasks.Add(Task.Run(() =>
                {
                    int iterations = 0;
                    for (int ctr = 1; ctr <= 2000; ctr++)
                    {
                        token.ThrowIfCancellationRequested();
                        iterations++;
                    }
                    Interlocked.Increment(ref completeIterations);
                    if (completeIterations >= 10)
                    {
                        source.Cancel();
                    }

                    return iterations;
                }, token));
            }

            Console.WriteLine("Waiting for the first 10 tasts to complete... \n");
            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Status of tasks: \n");
                Console.WriteLine("{0,10} {1,12} {2,14:N0}", "Task Id", "Status", "Iterations");
                foreach (var t in tasks)
                {
                    Console.WriteLine("{0,10} {1,12} {2,14}",
                        t.Id, t.Status,
                        t.Status != TaskStatus.Canceled ?
                        t.Result.ToString("N0") : "n/a");
                }
            }
            Console.ReadLine();
        }//End main
    }//End program
}
