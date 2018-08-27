using Minedraft.App.Core.Interfaces;

namespace Minedraft.App.Core.IO
{
    using System;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
