using System;

namespace Exercise_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string unquotedString = "The \"use\" of quotations causes difficulties.";
            string quotedString = @"The ""use"" of quotations causes difficulties.";

            Console.WriteLine($"Unquoted: {unquotedString}");
            Console.WriteLine($"Quoted: {quotedString}");
        }
    }
}
