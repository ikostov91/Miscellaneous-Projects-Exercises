namespace StorageMaster.App.Core.Commands
{
    using Core.Interfaces;

    public class UnloadVehicleCommand : ICommand
    {
        private StorageMaster storageMaster;

        public UnloadVehicleCommand(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.storageMaster.UnloadVehicle(input[0], int.Parse(input[1]));
            return output;
        }
    }
}
