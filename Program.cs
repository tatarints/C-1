using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Process[] process = Process.GetProcesses();
            foreach (var p in process)
            {
                Console.WriteLine($"{p.Id} {p.ProcessName}");
            }
            Console.Write("ID = ");
            var ID = Console.ReadLine();
            try
            {
                process.First(p => p.ProcessName.ToLower() == ID.ToLower()).Kill();
                Console.WriteLine($"{ID} process is closed");
            }
            catch (Exception)
            {
                Console.WriteLine($"{ID} incorrectly entered");
            }



            //2
            string[,] array = new string[4, 4];
            int sum = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine("Введите элемент {0}{1}:\n", i + 1, j + 1);
                    array[i, j] = Console.ReadLine();
                    try
                    {
                        sum += Int32.Parse(array[i, j]);
                    }
                    catch (MyArrayDataException ex)
                    {
                        new MyArrayDataException(i, j);
                    }
                    Console.WriteLine(sum);
                }
            }
            
            
            
        }
    }
}
