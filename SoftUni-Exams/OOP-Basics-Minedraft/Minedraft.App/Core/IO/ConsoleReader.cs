namespace Minedraft.App.Core.IO
{
    using Minedraft.App.Core.Interfaces;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

