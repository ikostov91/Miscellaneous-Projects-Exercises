namespace StorageMaster.App.Core.IO.Interfaces
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
