namespace StorageMaster
{
    using StorageMaster.Core;
    using StorageMaster.Core.Interfaces;
    using StorageMaster.Core.IO;
    using StorageMaster.Core.IO.Interfaces;

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
