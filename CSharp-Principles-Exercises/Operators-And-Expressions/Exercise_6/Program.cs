using System;

namespace Exercise_6
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double perimeter = 2 * length + 2 * height;
            double area = length * height;

            Console.WriteLine($"Perimeter: {perimeter}");
            Console.WriteLine($"Area: {area}");
        }
    }
}
