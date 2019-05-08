using System;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            float floatTypeOne = 12.345f;
            double doubleTypeOne = 8923.1234857;
            double doubleTypeTwo = 34.567839023;
            decimal decimalTypeOne = 3456.091124875956542151256683467m;

            Console.WriteLine($"Float: {floatTypeOne}" + Environment.NewLine +
                                $"Double: {doubleTypeOne}" + Environment.NewLine +
                                $"Double: {doubleTypeTwo}" + Environment.NewLine +
                                $"Decimal: {decimalTypeOne}");
        }
    }
}
