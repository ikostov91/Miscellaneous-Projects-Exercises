using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.App.Core.Interfaces;

namespace DungeonsAndCodeWizards.Core.Commands
{
    public class AddItemToPoolCommand : ICommand
    {
        private DungeonMaster dungeonMaster;

        public AddItemToPoolCommand(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.dungeonMaster.AddItemToPool(input);
            return output;
        }
    }
}
