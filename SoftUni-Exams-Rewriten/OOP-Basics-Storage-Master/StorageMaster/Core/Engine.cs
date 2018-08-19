namespace StorageMaster.Core
{
    using System;
    using Interfaces;
    using IO.Interfaces;

    public class Engine
    {
        private bool isRunning;

        private IWriter writer;
        private IReader reader;
        private ICommandInterpreter commandInterpreter;

        public Engine(IWriter writer, IReader reader, ICommandInterpreter commandInterpreter)
        {
            this.isRunning = true;
            this.writer = writer;
            this.reader = reader;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = this.reader.ReadLine();
                    string output = this.commandInterpreter.InterpretCommand(input);
                    this.writer.WriteLine(output);

                    if (input.StartsWith("END"))
                    {
                        this.isRunning = false;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    this.writer.WriteLine("Error: " + ioe.Message);
                }

                if (!isRunning)
                {
                    return;
                }
            }
        }
    }
}
