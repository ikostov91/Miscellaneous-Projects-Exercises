namespace DungeonsAndCodeWizards.App
{
    using DungeonsAndCodeWizards.App.AppCore.IO;
    using DungeonsAndCodeWizards.App.Core.Interfaces;
    using DungeonsAndCodeWizards.App.Core.IO;
    using DungeonsAndCodeWizards.Core;

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
