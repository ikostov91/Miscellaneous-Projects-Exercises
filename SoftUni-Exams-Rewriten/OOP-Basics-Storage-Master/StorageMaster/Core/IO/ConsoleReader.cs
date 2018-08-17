using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Core.IO.Interfaces
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
