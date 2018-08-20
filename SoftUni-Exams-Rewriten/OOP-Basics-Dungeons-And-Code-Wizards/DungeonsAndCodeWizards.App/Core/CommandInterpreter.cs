using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DungeonsAndCodeWizards.App.Core.Interfaces;

namespace DungeonsAndCodeWizards.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private DungeonMaster dungeonMaster;

        public CommandInterpreter(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }
        
        public string InterpretCommand(string input)
        {
            string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string commandName = inputArgs[0] + "Command";
            string[] commandArgs = inputArgs.Skip(1).ToArray();

            var commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid Command!");
            }

            ICommand command = (ICommand) Activator.CreateInstance(commandType, this.dungeonMaster);

            string output = command.Execute(commandArgs.ToArray());
            return output;
        }
    }
}
