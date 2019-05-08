using System;

namespace Exercise_7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string hello = "Hello";
            string world = "World";

            object helloWorldObj = "Hello" + " " + "World";
            Console.WriteLine($"Object: {helloWorldObj}");

            string helloWorldStr = (string)helloWorldObj;
            Console.WriteLine($"String: {helloWorldStr}");
        }
    }
}
