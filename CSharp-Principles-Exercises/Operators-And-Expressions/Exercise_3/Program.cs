using System;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int thirdDigit = (number / 100) % 10;

            if (thirdDigit == 7)
            {
                Console.WriteLine("Third digit is 7.");
            }
            else
            {
                Console.WriteLine($"Third digit is not 7: {thirdDigit}");
            }
        }
    }
}
