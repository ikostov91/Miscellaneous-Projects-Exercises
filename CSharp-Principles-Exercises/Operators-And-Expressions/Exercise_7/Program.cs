using System;

namespace Exercise_7
{
    class Program
    {
        static void Main(string[] args)
        {
            double weightOnEarth = double.Parse(Console.ReadLine());

            double weightOnMoon = weightOnEarth * 17 / 100;

            Console.WriteLine(weightOnMoon);
        }
    }
}
