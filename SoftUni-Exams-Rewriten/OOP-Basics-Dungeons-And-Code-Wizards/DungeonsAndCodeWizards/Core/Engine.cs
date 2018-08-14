using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Interfaces;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IWriter writer;
        private readonly IReader reader;

        private DungeonMaster dungeonMaster;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            this.isRunning = true;
        
            while (this.isRunning)
            {
                try
                {
                    this.ReadCommand();
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine($"Parameter Error: {ae.Message}");
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine($"Invalid Operation: {ioe.Message}");
                }

                if (this.dungeonMaster.IsGameOver() || isRunning == false) 
                {
                    writer.WriteLine("Final stats:");
                    writer.WriteLine(this.dungeonMaster.GetStats());
                    this.isRunning = false;
                }
            }
        }

        private void ReadCommand()
        {
            string input = reader.Read();
            string output = string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                this.isRunning = false;
                return;
            }

            string[] commandArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string commandName = commandArgs[0];
            string[] args = commandArgs.Skip(1).ToArray();
            
            switch (commandName)
            {
                case "JoinParty":
                    output = dungeonMaster.JoinParty(args);
                    break;
                case "AddItemToPool":
                    output = dungeonMaster.AddItemToPool(args);
                    break;
                case "PickUpItem":
                    output = dungeonMaster.PickUpItem(args);
                    break;
                case "UseItem":
                    output = dungeonMaster.UseItem(args);
                    break;
                case "UseItemOn":
                    output = dungeonMaster.UseItemOn(args);
                    break;
                case "GiveCharacterItem":
                    output = dungeonMaster.GiveCharacterItem(args);
                    break;
                case "GetStats":
                    output = dungeonMaster.GetStats();
                    break;
                case "Attack":
                    output = dungeonMaster.Attack(args);
                    break;
                case "Heal":
                    output = dungeonMaster.Heal(args);
                    break;
                case "EndTurn":
                    output = dungeonMaster.EndTurn(args);
                    break;
                default:
                    throw new ArgumentException("Invalid Command!");
            }

            if (output != string.Empty)
            {
                writer.WriteLine(output);
            }
        }
    }
}
