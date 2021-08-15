using System;

namespace lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Количество чисел в строке");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Количество чисел в cтолбце");
            int b = int.Parse(Console.ReadLine());
            int[,] matrix = new int[b, a]; 

            int A = a;
            int B = b;

            int k = 1;
            int t = 0;
            int i = 0;
            int j = 0;
           
            while (k <= A * B)
            {
                for (i = t; i < a; i++)
                    matrix[j, i] = k++;
                    j = a - 1;
                for (i = t + 1; i < b; i++)
                    matrix[i, j] = k++;
                    j = b - 1;
                for (i = a - 2; i >= t; i--)
                    matrix[j, i] = k++;
                    j = t;
                for (i = b - 2; i > t; i--)
                    matrix[i, j] = k++;
                    a--;
                    b--;
                    t++;
                    j = t;
            }
            for (i = 0; i < matrix.GetLength(0); i++)
            {
                for (j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j]);
                    Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
