using System;

namespace Exercise_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool bit3 = (number & 8) != 0;

            Console.WriteLine($"Third bit is 1: {bit3}");
        }
    }
}
