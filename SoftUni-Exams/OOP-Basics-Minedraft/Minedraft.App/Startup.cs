namespace Minedraft.App
{
    using Core.Interfaces;
    using Minedraft.App.Core;
    using Minedraft.App.Core.IO;

    public class Startup
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(new DraftManager());

            Engine engine = new Engine(writer, reader, commandInterpreter);
            engine.Run();
        }
    }
}

