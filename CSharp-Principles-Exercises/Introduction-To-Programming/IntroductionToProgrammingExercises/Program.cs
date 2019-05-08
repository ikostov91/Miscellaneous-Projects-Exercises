using System;

namespace IntroductionToProgrammingExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayFirstNameAndLastName();
            DisplayNumbersOnNewLine();
            DisplayCurrentDateAndTime();
            DisplaySquareRootOfNumber();
            DisplayFirst100Items();
        }

        private static void DisplayFirstNameAndLastName()
        {
            string firstName = "Ivaylo";
            string lastName = "Kostov";
            Console.WriteLine("Exercise 6:" + Environment.NewLine + 
                                $"{firstName} {lastName}" + Environment.NewLine);
        }

        private static void DisplayNumbersOnNewLine()
        {
            Console.WriteLine("Exercise 7:" + Environment.NewLine + 
                                1 + Environment.NewLine + 
                                101 + Environment.NewLine + 
                                1001 + Environment.NewLine);
        }

        private static void DisplayCurrentDateAndTime()
        {
            Console.WriteLine("Exercise 8:" + Environment.NewLine + 
                                $"Current date and time: {DateTime.Now}" + Environment.NewLine);
        }

        private static void DisplaySquareRootOfNumber()
        {
            int number = 12345;
            double squareRoot = Math.Sqrt(number);
            Console.WriteLine("Exercise 9:" + Environment.NewLine + 
                                $"Square root of {number}: {squareRoot}" + Environment.NewLine);
        }

        private static void DisplayFirst100Items()
        {
            int startNumber = 2;
            Console.WriteLine("Exercise 10:");
            for (int i = startNumber; i <= 100; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine($"-{i}");
                }
            }
            Console.WriteLine();
        }
    }
}
