using DungeonsAndCodeWizards.App.Core.Interfaces;

namespace DungeonsAndCodeWizards.Core.Commands
{
    public class UseItemOnCommand : ICommand
    {
        private DungeonMaster dungeonMaster;

        public UseItemOnCommand(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.dungeonMaster.UseItemOn(input);
            return output;
        }
    }
}
