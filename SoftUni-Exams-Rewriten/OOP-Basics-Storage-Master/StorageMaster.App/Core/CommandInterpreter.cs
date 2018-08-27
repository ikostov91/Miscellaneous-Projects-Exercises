namespace StorageMaster.App.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;

    public class CommandInterpreter : ICommandInterpreter
    {
        private StorageMaster storageMaster;

        public CommandInterpreter(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
        }

        public string InterpretCommand(string input)
        {
            string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string commandName = inputArgs[0] + "Command";

            var commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var command = (ICommand) Activator.CreateInstance(commandType, this.storageMaster);
            string output = command.Execute(inputArgs.Skip(1).ToArray());
            return output;
        }
    }
}
