using System;

namespace lesson_4
{
    class Program
    {
        //1
        static void Main(string[] args)
        {
            GetFullName("Петров", "Алексей", "Викторович");
            GetFullName("Румянцев", "Артём", "Прохорович");
            GetFullName("Мельникова", "Елизавета", "Алексеевна");
            GetFullName("Татаринцева", "Татьяна", "Владимировна");
        }

        static void GetFullName(string lastName, string firstName, string patronymic)
        {
            Console.WriteLine($"{lastName} {firstName} {patronymic}");
        }



        //2
        static void Main(string[] args)
        {
            GetSum();

            Console.WriteLine();

            Console.ReadKey();
        }

        static void GetSum()
        {
            string text = Console.ReadLine();
            //int num = Convert.ToInt32(text);
            //string[] num = text.Split(' ');
            //int[] num = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var num = text.Split().Select(int.Parse).ToArray();
            //var num = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.TryParse);
            int sum = num.Sum();
            Console.WriteLine(sum);
        }



        //3
        static void Main(string[] args)
        {
                Console.WriteLine("Введите номер месяца: ");
                Console.WriteLine(Season(Month(Convert.ToInt32(Console.ReadLine()))));
        }
        enum season { Winter, Spring, Summer, Autumn }
        static season Month(int n)
        {
             
                if (n <= 0 || n > 12)
                {
                    Console.WriteLine("Ошибка: введите число от 1 до 12");
                }
                switch ((n % 12) / 3)
                {
                    case 0:
                        return season.Winter;
                    case 1:
                        return season.Spring;
                    case 2:
                        return season.Summer;
                    default:
                        return season.Autumn;
                }
           
        }
        static string Season(season s)
        {
            switch (s)
            {
                case season.Winter:
                    return "Зима";
                case season.Spring:
                    return "Весна";
                case season.Summer:
                    return "Лето";
                case season.Autumn:
                    return "Осень";
                default: return "";
            }
        }
        
    }
}
