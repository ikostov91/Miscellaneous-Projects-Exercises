using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.App.Core.Interfaces;

namespace DungeonsAndCodeWizards.Core.Commands
{
    public class GiveCharacterItemCommand : ICommand
    {
        private DungeonMaster dungeonMaster;

        public GiveCharacterItemCommand(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.dungeonMaster.GiveCharacterItem(input);
            return output;
        }
    }
}
