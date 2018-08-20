using System;
using DungeonsAndCodeWizards.App.Core.Interfaces;
using DungeonsAndCodeWizards.App.Interfaces;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ICommandInterpreter commandInterpreter;
        private readonly DungeonMaster dungeonMaster;

        public Engine(IWriter writer, IReader reader, DungeonMaster dungeonMaster, ICommandInterpreter commandInterpreter)
        {
            this.writer = writer;
            this.reader = reader;
            this.dungeonMaster = dungeonMaster;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            this.isRunning = true;
        
            while (this.isRunning)
            {
                try
                {
                    string input = this.reader.Read();

                    if (string.IsNullOrEmpty(input))
                    {
                        break;
                    }

                    string output = this.commandInterpreter.InterpretCommand(input);
                    this.writer.WriteLine(output);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine($"Parameter Error: {ae.Message}");
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine($"Invalid Operation: {ioe.Message}");
                }

                if (this.dungeonMaster.IsGameOver())
                {                    
                    this.isRunning = false;
                }
            }

            string endStats = this.dungeonMaster.GetStats();
            writer.WriteLine("Final stats:");
            writer.WriteLine(endStats);
        }
    }
}
