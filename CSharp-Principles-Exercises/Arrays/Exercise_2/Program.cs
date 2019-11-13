using System;
using System.Linq;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOne = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] arrayTwo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            if (arrayOne.Length != arrayTwo.Length)
            {
                Console.WriteLine("Not Equal!");
                return;
            }

            for (int i = 0; i < arrayOne.Length; i++)
            {
                if (arrayOne[i] != arrayTwo[i])
                {
                    Console.WriteLine("Not Equal!");
                    return;
                }
            }

            Console.WriteLine("Arrays are equal!");
        }
    }
}
