using System;

namespace Exercise_13
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 5;
            int secondNumber = 10;
            Console.WriteLine($"Before swap: {firstNumber} {secondNumber}");

            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
            Console.WriteLine($"After swap: {firstNumber} {secondNumber}");
        }
    }
}
