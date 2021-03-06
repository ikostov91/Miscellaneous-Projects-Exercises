﻿namespace Minedraft.App.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Minedraft.App.Core.Interfaces;

    class CommandInterpreter : ICommandInterpreter
    {
        private DraftManager draftManager;

        public CommandInterpreter(DraftManager draftManager)
        {
            this.draftManager = draftManager;
        }

        public string InterpretCommand(string input)
        {
            string[] userInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = userInput[0];
            string output = string.Empty;

            MethodInfo method = this.draftManager.GetType().GetMethods().FirstOrDefault(x => x.Name == commandName);
            output = (string)method.Invoke(this.draftManager, userInput.Skip(1).ToList().Count == 0 ? new object[] { } : new object[] { userInput.Skip(1).ToList() });

            return output;
        }
    }
}
