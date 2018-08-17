using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Core.IO.Interfaces;

namespace StorageMaster.Core
{
    public class Engine
    {
        private bool isRunning;

        private IWriter writer;
        private IReader reader;
        private StorageMaster storageMaster;

        public Engine(IWriter writer, IReader reader)
        {
            this.isRunning = true;
            this.writer = writer;
            this.reader = reader;
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            while (true)
            {
                if (!isRunning)
                {
                    return;
                }

                try
                {
                    string input = this.reader.ReadLine();
                    string output = this.ReadCommand(input);
                    this.writer.WriteLine(output);
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

        private string ReadCommand(string input)
        {
            string[] parameters = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string commandName = parameters[0];
            string[] commandArgs = parameters.Skip(1).ToArray();

            string output = string.Empty;

            switch (commandName)
            {
                case "AddProduct":
                    output = this.storageMaster.AddProduct(commandArgs[0], double.Parse(commandArgs[1]));
                    break;
                case "RegisterStorage":
                    output = this.storageMaster.RegisterStorage(commandArgs[0], commandArgs[1]);
                    break;
                case "SelectVehicle":
                    output = this.storageMaster.SelectVehicle(commandArgs[0], int.Parse(commandArgs[1]));
                    break;
                case "LoadVehicle":
                    output = this.storageMaster.LoadVehicle(commandArgs);
                    break;
                case "SendVehicleTo":
                    output = this.storageMaster.SendVehicleTo(commandArgs[0], int.Parse(commandArgs[1]), commandArgs[2]);
                    break;
                case "UnloadVehicle":
                    output = this.storageMaster.UnloadVehicle(commandArgs[0], int.Parse(commandArgs[1]));
                    break;
                case "GetStorageStatus":
                    output = this.storageMaster.GetStorageStatus(commandArgs[0]);
                    break;
                case "END":
                    output = this.storageMaster.GetSummary();
                    this.isRunning = false;
                    break;
            }

            return output;
        }
    }
}
