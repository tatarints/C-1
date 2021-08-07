using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            string filename = "text.txt";
            File.WriteAllText(filename, Console.ReadLine());



            //2
            string filedate = "startup.txt";
            DateTime time = DateTime.Now;
            string times = time.ToString();
            File.WriteAllText(filedate, times);

        }
    }




    //3
    [Serializable]
    class Numbers
    {
        public string Num { get; set; }
        public Numbers(string num)
        {
            Num = num;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // объект для сериализации
            Console.WriteLine("Введите с клавиатуры произвольный набор чисел 0...255");
            Numbers numbers = new Numbers(Console.ReadLine());
            Console.WriteLine("Объект создан");

            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("numb.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, numbers);

                Console.WriteLine("Объект сериализован");
            }

            Console.ReadLine();
        }
    }



    //4


    class Program
    {
        static void Main(string[] args)
        {
            Person[] persArray = {
             new Person("Ivanov Ivan", "Engineer", "ivivan@mailbox.com", "892312312", 30000, 30),
             new Person("Efremov Dima", "Doctor", "efre@gmail.com", "89920188721", 36000, 20),
             new Person("Tatarintsev Vova", "Military officer", "tata@mailbox.com", "89785670954", 45000, 43),
             new Person("Melkin Sasha", "Engineer", "samel@mailbox.com", "89874564327", 20000, 45),
             new Person("Lepen Zhenya", "Driver", "lezh@mailbox.com", "89238764563", 16000, 24),
            };
            for (int i = 0; i < persArray.Length; i++)
            {
                if (persArray[i].birthyear > 40)
                {
                    Console.WriteLine(persArray[i].Info());
                }
            }
            Console.WriteLine();
            for (int i = 0; i < persArray.Length; i++)
            {
                Console.WriteLine(persArray[i].Info());
            }
            Console.WriteLine();
        }
    }
}
    

   
