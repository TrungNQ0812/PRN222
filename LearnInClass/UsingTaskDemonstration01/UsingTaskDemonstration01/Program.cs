﻿namespace UsingTaskDemonstration01
{
    class Program
    {
        static void PrintNumber(string Message)
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{Message} : {i}");
                Thread.Sleep(1000); 
            }
        }

        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";

            Task task01 = new Task(() => PrintNumber("Task 01"));
            task01.Start();

            Task task02 = Task.Run(delegate
            {
                PrintNumber("Task 02");
            });

            Task task03 = new Task(new Action(() =>
            {
                PrintNumber("Task 03");
            }));
        
            task03.Start();
            Console.WriteLine($"Thread '{Thread.CurrentThread.Name}'");
            Console.ReadKey();
        }
    }
}
