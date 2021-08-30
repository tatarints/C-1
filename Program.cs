using System;

namespace lesson_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            int n = Convert.ToInt32(Console.ReadLine());
            int d = 0;
            int i = 2;

            while (i < n)
            {
                if ((n % i) == 0)
                {
                    d++; i++;
                }
                else
                {
                    i++;
                }

            }
            if (d == 0)
            {
                Console.WriteLine("Простое");
            }
            else
            {
                Console.WriteLine("Не простое");
            }



            //2
            //сложность функции сотставила O(n^2)
            
            
            
            //3
            Console.WriteLine("До какого числа считать ряд Фибоначчи?");
            int number = Convert.ToInt32(Console.ReadLine());

            int perv = 1;
            Console.Write("{0} ", perv);
            int vtor = 1;
            Console.Write("{0} ", vtor);
            int sum = 0;

            while (number >= sum)
            {
                sum = perv + vtor;
                Console.Write("{0} ", sum);
                perv = vtor;
                vtor = sum;
            }
        }
    }
}

