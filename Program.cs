using System;

namespace lesson1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Написать программу, выводящую в консоль текст: «Привет, %имя пользователя%, сегодня %дата%». Имя пользователя сохранить из консоли в промежуточную переменную.
           
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("What is the date today?");
            string date = Console.ReadLine();

            Console.WriteLine($"Hi,{name}. Today: {date}");
        }
    }
}
