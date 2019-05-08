using System;

namespace Exercise_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Ivaylo";
            string lastName = "Kostov";
            int age = 27;
            char gender = 'm';
            long uniqueEmployeeNumber = 27569999;

            Console.WriteLine("Employee Info" + Environment.NewLine +
                                $"Name: {firstName} {lastName}" + Environment.NewLine + 
                                $"Age: {age}" + Environment.NewLine + 
                                $"Gender: {gender}" + Environment.NewLine + 
                                $"Unique Employee Number: {uniqueEmployeeNumber}");
        }
    }
}
