using System;

namespace Exercise_9
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool insideCircle = (x * x) + (y * y) <= 25;
            bool insideRectangle = (x >= -1 && x <= 5) && (y >= 1 && y <= 5);

            if (insideCircle && insideRectangle)
            {
                Console.WriteLine("Point is inside circle AND rectangle.");
            }
            else if (insideCircle)
            {
                Console.WriteLine("Point is inside of circle and outside of rectangle.");
            }
            else if (insideRectangle)
            {
                Console.WriteLine("Point is outside of circle and inside of rectangle.");
            }
            else
            {
                Console.WriteLine("Point is both outside of circle and rectangle.");
            }
        }
    }
}
