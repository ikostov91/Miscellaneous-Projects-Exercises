using System;

namespace Exercise_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i * 5;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
