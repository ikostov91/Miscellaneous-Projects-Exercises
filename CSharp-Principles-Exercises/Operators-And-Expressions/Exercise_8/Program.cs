using System;

namespace Exercise_8
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            var result = (x * x) + (y * y);

            if (result <= 25)
            {
                Console.WriteLine("Point is in circle.");
            }
            else
            {
                Console.WriteLine("Point is outside of circle.");
            }
        }
    }
}
