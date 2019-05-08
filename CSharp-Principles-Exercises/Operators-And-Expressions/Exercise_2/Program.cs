using System;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool isDividible = (number % 7 == 0) && (number % 5 == 0);

            Console.WriteLine(isDividible);
        }
    }
}
