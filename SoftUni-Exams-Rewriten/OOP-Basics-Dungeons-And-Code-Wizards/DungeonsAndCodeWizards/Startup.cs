using System;
using DungeonsAndCodeWizards.Core;
using DungeonsAndCodeWizards.Core.IO;
using DungeonsAndCodeWizards.Models.Interfaces;

namespace DungeonsAndCodeWizards
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            Engine engine = new Engine(writer, reader);
            engine.Run();
        }
    }
}
