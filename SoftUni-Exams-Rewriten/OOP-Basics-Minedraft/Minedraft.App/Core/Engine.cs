using Core.Interfaces;
using Minedraft.Models.Exceptions;

namespace Minedraft.App.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Minedraft.App.Core.Interfaces;

    public class Engine : IEngine
    {
        //private DraftManager draftManager;
        private ICommandInterpreter commandInterpreter;
        private IWriter writer;
        private IReader reader;

        public Engine(IWriter writer, IReader reader, ICommandInterpreter commandInterpreter)
        {
            //this.draftManager = new DraftManager();
            this.commandInterpreter = commandInterpreter;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = reader.ReadLine();
                    string result = commandInterpreter.InterpretCommand(input);
                    this.writer.WriteLine(result);

                    if (input.StartsWith("Shutdown"))
                    {
                        return;
                    }
                }
                catch (Exception e)
                    when (e is HarvesterNotRegisteredException
                          || e is ProviderNotRegisteredException
                          || e is InvalidSystemModeException
                          || e is InvalidHarvesterTypeException
                          || e is InvalidProviderTypeException
                          || e is TargetInvocationException)
                {
                    this.writer.WriteLine(e.Message);
                }
            }
        }
    }
}

