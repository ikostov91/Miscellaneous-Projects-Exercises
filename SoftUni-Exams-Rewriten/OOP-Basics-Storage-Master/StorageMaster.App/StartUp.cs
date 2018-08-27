namespace StorageMaster.App
{
    using StorageMaster.App.Core;
    using StorageMaster.App.Core.Interfaces;
    using StorageMaster.App.Core.IO;
    using StorageMaster.App.Core.IO.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            StorageMaster storageMaster = new StorageMaster();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(storageMaster);

            Engine engine = new Engine(writer, reader, commandInterpreter);
            engine.Run();
        }
    }
}
