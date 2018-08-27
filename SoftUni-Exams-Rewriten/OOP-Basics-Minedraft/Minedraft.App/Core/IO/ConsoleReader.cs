using Minedraft.App.Core.Interfaces;

namespace Minedraft.App.Core.IO
{
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

