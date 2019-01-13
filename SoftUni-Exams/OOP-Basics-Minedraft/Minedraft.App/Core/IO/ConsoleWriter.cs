namespace Minedraft.App.Core.IO
{
    using Minedraft.App.Core.Interfaces;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
