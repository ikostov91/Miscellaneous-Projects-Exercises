using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.App.Core.Interfaces;

namespace DungeonsAndCodeWizards.Core.Commands
{
    public class UseItemCommand : ICommand
    {
        private DungeonMaster dungeonMaster;

        public UseItemCommand(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.dungeonMaster.UseItem(input);
            return output;
        }
    }
}
