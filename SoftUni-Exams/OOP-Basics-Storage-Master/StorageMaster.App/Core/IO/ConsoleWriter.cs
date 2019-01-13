namespace StorageMaster.App.Core.IO
{
    using System;
    using Core.IO.Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
