using System;
using DungeonsAndCodeWizards.Core;
using DungeonsAndCodeWizards.Core.Interfaces;
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

            DungeonMaster dungeonMaster = new DungeonMaster();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(dungeonMaster);

            Engine engine = new Engine(writer, reader, dungeonMaster, commandInterpreter);
            engine.Run();
        }
    }
}
