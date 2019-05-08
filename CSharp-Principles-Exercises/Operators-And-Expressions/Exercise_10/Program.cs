using System;

namespace Exercise_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < 1000 || number > 9999)
            {
                Console.WriteLine("Number is not valid.");
                return;
            }

            int copy = number;
            int firstDigit = copy % 10;
            int secondDigit = (copy / 10) % 10;
            int thirdDigit = (copy / 100) % 10;
            int fourthDigit = (copy / 1000) % 10;

            int sumOfDigits = firstDigit + secondDigit + thirdDigit + fourthDigit;
            Console.WriteLine($"Sum of digits: {sumOfDigits}");

            Console.WriteLine($"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit}");

            int lastDigitMoved = Convert.ToInt32($"{firstDigit}{fourthDigit}{thirdDigit}{secondDigit}");
            Console.WriteLine($"Last digit moved to first place: {lastDigitMoved}");

            int middleDigitsSwapped = Convert.ToInt32($"{fourthDigit}{secondDigit}{thirdDigit}{firstDigit}");
            Console.WriteLine($"Middle two digits swapped: {middleDigitsSwapped}");
        }
    }
}
