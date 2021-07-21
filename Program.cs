using System;

namespace lesson1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("What is the date today?");
            string date = Console.ReadLine();

            Console.WriteLine($"Hi,{name}. Today: {date}");
        }
    }
}
