using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.App.Core.Interfaces;

namespace DungeonsAndCodeWizards.Core.Commands
{
    public class PickUpItemCommand : ICommand
    {
        private DungeonMaster dungeonMaster;

        public PickUpItemCommand(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.dungeonMaster.PickUpItem(input);
            return output;
        }
    }
}
