using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Core.IO.Interfaces;

namespace StorageMaster.Core.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
