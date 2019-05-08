using System;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOne = double.Parse(Console.ReadLine());
            double numberTwo = double.Parse(Console.ReadLine());

            bool areEqual = Math.Abs(numberOne - numberTwo) < 0.000001;

            Console.WriteLine($"{numberOne} == {numberTwo} => {areEqual}");
        }
    }
}
