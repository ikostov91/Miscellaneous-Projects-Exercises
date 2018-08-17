using System;
using StorageMaster.Core;
using StorageMaster.Core.IO;
using StorageMaster.Core.IO.Interfaces;

namespace StorageMaster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            Engine engine = new Engine(writer, reader);
            engine.Run();
        }
    }
}
